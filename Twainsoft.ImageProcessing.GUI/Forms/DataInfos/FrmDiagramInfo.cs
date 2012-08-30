#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.GUI.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using System.Windows.Forms.DataVisualization.Charting;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Forms.DataInfos
{
    public partial class FrmDiagramInfo : FrmDataInfoBase
    {
        public FrmDiagramInfo()
        {
            InitializeComponent();
        }

        public void SetOutputData(IEBCOutputData ebcOutputData)
        {
            this.ucDiagramInfo.PopulateData(ebcOutputData.EBCMessageData.Data);
        }
    }
}