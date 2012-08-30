#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Execution;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using System.Diagnostics;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using System.ComponentModel;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Execution
{
    public class ExecutionController : IExecutionController
    {
        private Dictionary<IEBCBase, IEBCMessage> EBCInputData { get; set; }

        private Stopwatch Stopwatch { get; set; }

        private Dictionary<IEBCBase, Dictionary<IEBCBase, Action<IEBCMessage>>> EBCOutputConnections { get; set; }
        private Dictionary<IEBCBase, List<IEBCBase>> EBCInputConnections { get; set; }

        private Dictionary<IEBCBase, IEBCExecutionTimeData> EBCExecutionTimes { get; set; }

        private List<IEBCBase> IncorrectEBCs { get; set; }

        public ExecutionController()
        {
            this.EBCInputData = new Dictionary<IEBCBase, IEBCMessage>();
            this.Stopwatch = new Stopwatch();
            this.EBCOutputConnections = new Dictionary<IEBCBase, Dictionary<IEBCBase, Action<IEBCMessage>>>();
            this.EBCInputConnections = new Dictionary<IEBCBase, List<IEBCBase>>();

            this.EBCExecutionTimes = new Dictionary<IEBCBase, IEBCExecutionTimeData>();

            this.IncorrectEBCs = new List<IEBCBase>();
        }

        public void In_ConnectEBCs(IConnectEBCMessage connectEBCMessage)
        {
            IEBCBase outputEBC = connectEBCMessage.OutputEBC;
            IEBCBase inputEBC = connectEBCMessage.InputEBC;

            this.ConnectEBC(outputEBC, inputEBC);
        }

        private void ConnectEBC(IEBCBase outputEBC, IEBCBase inputEBC)
        {
            outputEBC.Out_SendMessage += (IEBCMessage ebcMessage) => this.EBCInputData[inputEBC] = ebcMessage;

            if (!this.EBCOutputConnections.ContainsKey(outputEBC))
            {
                Dictionary<IEBCBase, Action<IEBCMessage>> inputEBCsAndMessages = new Dictionary<IEBCBase, Action<IEBCMessage>>();
                inputEBCsAndMessages.Add(inputEBC, (IEBCMessage ebcMessage) => inputEBC.In_ReceiveMessage(ebcMessage));

                this.EBCOutputConnections.Add(outputEBC, inputEBCsAndMessages);
            }
            else
            {
                // If there's already a Connection between those Shapes, cancel the new one.
                if (this.EBCOutputConnections[outputEBC].ContainsKey(inputEBC))
                    throw new ShapeConnectionException("Eine entsprechende Verbindung ist schon vorhanden und kann nicht erneut angelegt werden!");

                this.EBCOutputConnections[outputEBC].Add(inputEBC, (IEBCMessage ebcMessage) => inputEBC.In_ReceiveMessage(ebcMessage));
            }

            try
            {
                // Check for circular connections.
                this.DetectCircularConnections(outputEBC, outputEBC);

                if (!this.EBCInputConnections.ContainsKey(inputEBC))
                {
                    List<IEBCBase> outputEBCs = new List<IEBCBase>();
                    outputEBCs.Add(outputEBC);

                    this.EBCInputConnections.Add(inputEBC, outputEBCs);
                }
                else
                {
                    this.EBCInputConnections[inputEBC].Add(outputEBC);
                }

                outputEBC.Out_SendMessage += this.EBCOutputConnections[outputEBC][inputEBC];
            }
            catch (CircularConnectionException circularConnectionException)
            {
                this.EBCOutputConnections.Remove(outputEBC);

                throw circularConnectionException;
            }
        }

        public void In_DisconnectEBCs(IDisconnectEBCMessage disconnectEBCMessage)
        {
            this.DisconnectEBC(disconnectEBCMessage.OutputEBC, disconnectEBCMessage.InputEBC);
        }

        private void DisconnectEBC(IEBCBase outputEBC, IEBCBase inputEBC)
        {
            outputEBC.Out_SendMessage -= this.EBCOutputConnections[outputEBC][inputEBC];

            this.EBCOutputConnections[outputEBC].Remove(inputEBC);

            this.EBCInputConnections.Remove(inputEBC);
        }

        private void DetectCircularConnections(IEBCBase outputEBC, IEBCBase referenceEBC)
        {
            foreach (var ebc in this.EBCOutputConnections[outputEBC].Keys)
            {
                if (ebc == referenceEBC)
                {
                    throw new CircularConnectionException("Die aktuelle Verbindung kann aufgrund einer Zirkularität nicht erstellt werden!");
                }
                else if (this.EBCOutputConnections.ContainsKey(ebc))
                {
                    this.DetectCircularConnections(ebc, referenceEBC);
                }
            }
        }

        public void In_ExecuteFirstEBC(IExecuteFirstEBCMessage executeFirstEBCMessage)
        {
            IEBCBase firstEBC = executeFirstEBCMessage.EBC;

            this.EBCExecutionTimes.Clear();

            this.Stopwatch.Restart();

            this.StartEBCWork(firstEBC);
        }

        private void StartEBCWork(IEBCBase firstEBC)
        {
            if (this.EBCInputData.ContainsKey(firstEBC))
                firstEBC.In_ReceiveMessage(this.EBCInputData[firstEBC]);
            else
                firstEBC.In_ReceiveMessage(null);
        }

        public void In_EBCAdded(IEBCBase ebc)
        {
            ebc.Out_SendMessage += (IEBCMessage ebcMessage) => this.CalcDateTime(ebc);
            ebc.Out_SendMessage += (IEBCMessage ebcMessage) => this.ProtocolOutputData(ebc, ebcMessage);
            ebc.Out_EBCDebugMessage += (IEBCDebugMessage ebcDebugMessage) => this.ProcotolDebugData(ebcDebugMessage);
            ebc.Out_WorkException += (IEBCExceptionMessage ebcExceptionMessage) => this.Out_EBCWorkExceptionHandled(ebcExceptionMessage);
        }

        private void ProcotolDebugData(IEBCDebugMessage ebcDebugMessage)
        {
            this.Out_EBCDebugMessage(ebcDebugMessage);
        }

        private void ProtocolOutputData(IEBCBase ebcBase, IEBCMessage ebcMessage)
        {
            // Send the elapsed time to the associated shape.
            ebcBase.ExecutionFinished(new ExecutionTimeMessage(this.EBCExecutionTimes[ebcBase].UsedMilliseconds));

            if (ebcBase.CanProtocolOutputData)
            {
                this.Out_ExecutionFinished(new ExecutionFinishedMessage(this.EBCExecutionTimes[ebcBase],
                    new EBCOutputData(ebcBase, ebcMessage.EBCMessageData, EBCOutputDataTypes.Result)));
            }
            else
            {
                this.Out_ExecutionFinished(new ExecutionFinishedMessage(this.EBCExecutionTimes[ebcBase]));
            }
        }

        private void CalcDateTime(IEBCBase ebcBase)
        {
            this.Stopwatch.Stop();

            if (!this.EBCExecutionTimes.ContainsKey(ebcBase))
            {
                this.EBCExecutionTimes.Add(ebcBase, new EBCExecutionTimeData(DateTime.Now.TimeOfDay, this.Stopwatch.ElapsedMilliseconds, ebcBase));
            }
            else
            {
                this.EBCExecutionTimes[ebcBase] = new EBCExecutionTimeData(DateTime.Now.TimeOfDay, this.Stopwatch.ElapsedMilliseconds, ebcBase);
            }

            this.Stopwatch.Restart();
        }

        public void In_DeleteEBC(IEBCBase ebc)
        {
            if (this.EBCOutputConnections.ContainsKey(ebc))
            {
                // Remove all SendMessage events to the target ebcs.
                foreach (var ebcToEBCMessages in this.EBCOutputConnections[ebc])
                {
                    ebc.Out_SendMessage -= ebcToEBCMessages.Value;

                    this.EBCInputConnections.Remove(ebcToEBCMessages.Key);
                }

                this.EBCOutputConnections.Remove(ebc);
            }

            if (this.EBCInputConnections.ContainsKey(ebc))
            {
                foreach (var inputEBC in this.EBCInputConnections[ebc])
                {
                    if (this.EBCOutputConnections.ContainsKey(inputEBC))
                    {
                        bool completeDeletion = true;
                        foreach (var item3 in this.EBCOutputConnections[inputEBC])
                        {
                            if (item3.Key == ebc)
                                inputEBC.Out_SendMessage -= item3.Value;
                            else
                                completeDeletion = false;
                        }

                        if (completeDeletion)
                            this.EBCOutputConnections.Remove(inputEBC);
                    }
                }

                this.EBCInputConnections.Remove(ebc);
            }

            this.EBCInputData.Remove(ebc);
            this.EBCExecutionTimes.Remove(ebc);
        }

        public event Action<IExecutionFinishedMessage> Out_ExecutionFinished;

        public event Action<IEBCExceptionMessage> Out_EBCWorkExceptionHandled;

        public event Action<IEBCDebugMessage> Out_EBCDebugMessage;
    }
}