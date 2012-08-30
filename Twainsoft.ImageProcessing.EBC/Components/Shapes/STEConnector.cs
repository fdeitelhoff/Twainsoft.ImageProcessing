#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Shapes;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using System.Reflection;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Shapes
{
    public class STEConnector : ISTEConnector
    {
        enum ConnectDirections
        {
            EBCToShape,
            ShapeToEBC
        }

        public STEConnector() { }

        public void In_STEAutoConnect(ISTEConnectMessage steConnectMessage)
        {
            this.ConnectShapeToEBC(steConnectMessage.Shape, steConnectMessage.EBC);
        }

        private void ConnectShapeToEBC(IShapeBase shape, IEBCBase ebc)
        {
            Type shapeType = shape.GetType();
            Type ebcType = ebc.GetType();

            // First, events of shapeBase to matching methods of ebcBase.
            EventInfo[] shapeBaseEvents = shapeType.GetEvents();
            MethodInfo[] ebcBaseMethods = ebcType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            this.AutoConnectEvents(ConnectDirections.ShapeToEBC, shape, ebc, shapeBaseEvents, ebcBaseMethods);

            // Second, events of ebcBase to matching methods of shapeBase.
            EventInfo[] ebcBaseEvent = ebcType.GetEvents();
            MethodInfo[] shapeBaseMethods = shapeType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

            this.AutoConnectEvents(ConnectDirections.EBCToShape, shape, ebc, ebcBaseEvent, shapeBaseMethods);

            // Last, set the EBC-Name to the shape.
            shape.Name = ebc.Name;
        }

        private void AutoConnectEvents(ConnectDirections connectDirection, IShapeBase shapeBase, IEBCBase ebcBase, EventInfo[] events, MethodInfo[] methods)
        {
            Dictionary<string, MethodInfo> methodInfoToName = new Dictionary<string, MethodInfo>();

            object eventSource = null;
            object firstDelegateArgument = null;

            // Shape to EBC
            if (connectDirection == ConnectDirections.ShapeToEBC)
            {
                eventSource = shapeBase;
                firstDelegateArgument = ebcBase;
            }
            // EBC to Shape
            else if (connectDirection == ConnectDirections.EBCToShape)
            {
                eventSource = ebcBase;
                firstDelegateArgument = shapeBase;
            }

            // Save all methods in a dictionary with it's name as key.
            foreach (var currentMethod in methods)
            {
                if (currentMethod.Name.StartsWith("In_"))
                    methodInfoToName.Add(currentMethod.Name.Replace("In_", ""), currentMethod);
            }

            // Iterate over all found EBC-events and check if there is a matching EBC-handler.
            foreach (var currentEvent in events)
            {
                if (currentEvent.Name.StartsWith("Out_"))
                {
                    string name = currentEvent.Name.Replace("Out_", "");

                    if (methodInfoToName.ContainsKey(name))
                    {
                        // Connect them.
                        currentEvent.AddEventHandler(eventSource,
                                Delegate.CreateDelegate(currentEvent.EventHandlerType, firstDelegateArgument, methodInfoToName[name]));
                    }
                }
            }
        }
    }
}