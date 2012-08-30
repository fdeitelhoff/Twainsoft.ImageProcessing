#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Shapes;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Components.Adapter;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Histogram;
using Twainsoft.ImageProcessing.EBC.Components.LUT;
using Twainsoft.ImageProcessing.Shapes.Components.Adapter;
using Twainsoft.ImageProcessing.Shapes.Components.LUT;
using Twainsoft.ImageProcessing.Shapes.Components.Scan;
using Twainsoft.ImageProcessing.EBC.Components.Scan;
using Twainsoft.ImageProcessing.Shapes.Components.Base;
using Twainsoft.ImageProcessing.EBC.Components.Operations;
using Twainsoft.ImageProcessing.Shapes.Components.Misc;
using Twainsoft.ImageProcessing.EBC.Components.WCF;
using Twainsoft.ImageProcessing.EBC.Components.Misc;
using Twainsoft.ImageProcessing.Shapes.Components.Thresh;
using Twainsoft.ImageProcessing.EBC.Components.Thresh;
using Twainsoft.ImageProcessing.EBC.Components.Ranking;
using Twainsoft.ImageProcessing.EBC.Components.Gradient;
using Twainsoft.ImageProcessing.EBC.Components.FloodFilling;
using Twainsoft.ImageProcessing.EBC.Components.Contrast;
using Twainsoft.ImageProcessing.EBC.Components.Examples;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Shapes
{
    public class ShapeCollector : IShapeCollector
    {
        public ShapeCollector() { }

        public void In_GetAvailableShapes()
        {
            Dictionary<IShapeInfoData, Type> shapesToEBCs = new Dictionary<IShapeInfoData, Type>();

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Adapter, "Bild laden", typeof(ImageLoadAdapterShape)), typeof(ImageLoadAdapter));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Adapter, "Bild speichern", typeof(ImageSaveAdapterShape)), typeof(ImageSaveAdapter));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Histogram, "Grauwerthistogramm", typeof(ShapeBase)), typeof(GrayValueHistogram));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Histogram, "Kum. Histogramm", typeof(ShapeBase)), typeof(CumulativeHistogram));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Histogram, "Histogramm ebnen", typeof(ShapeBase)), typeof(HistogramEqualiziation));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.LUT, "Look-Up-Table", typeof(LookUpTableShape)), typeof(LookUpTable));
            
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.ImageScan, "Line-Scan", typeof(LineScanShape)), typeof(LineScan));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.ImageScan, "Ellipse-Scan", typeof(EllipseScanShape)), typeof(EllipseScan));
            
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.ArithmeticOperations, "Subtraktion", typeof(ShapeBase)), typeof(Subtraction));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.ArithmeticOperations, "Addition", typeof(ShapeBase)), typeof(Addition));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Threshold, "Schwellwert", typeof(ThresholdShape)), typeof(Threshold));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.RankedOperations, "Dilatation", typeof(ShapeBase)), typeof(Dilatation));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.RankedOperations, "Erosion", typeof(ShapeBase)), typeof(Erodation));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.RankedOperations, "Median", typeof(ShapeBase)), typeof(Median));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.RankedOperations, "Opening", typeof(ShapeBase)), typeof(Opening));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.RankedOperations, "Closing", typeof(ShapeBase)), typeof(Closing));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.RankedOperations, "Laplace", typeof(ShapeBase)), typeof(Laplace));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Gradient, "Gradient-out", typeof(ShapeBase)), typeof(GradientOut));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Gradient, "Gradient-in", typeof(ShapeBase)), typeof(GradientIn));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.ROI, "ROI (Zentrum)", typeof(ShapeBase)), typeof(ROICenter));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.FloodFill, "Flood-Fill", typeof(ShapeBase)), typeof(FloodFill));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Contrast, "Kontrast anheben", typeof(ShapeBase)), typeof(IncreaseContrast));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Misc, "Bild-Repeater", typeof(ImageRepeaterShape)), typeof(ImageRepeater));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Misc, "Bild-Cache", typeof(ImageCacheShape)), typeof(ImageCache));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Misc, "Sender", typeof(SendImageShape)), typeof(SendImage));
            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Misc, "Empfänger", typeof(ReceiveImageShape)), typeof(ReceiveImage));

            shapesToEBCs.Add(new ShapeInfoData(ShapeGroups.Examples, "Flaschen-Prüfung", typeof(ShapeBase)), typeof(BottleCheck));

            IAvailableShapesMessage message = new AvailableShapesMessage(shapesToEBCs);

            this.Out_AvailableShapes(message);
        }

        public event Action<IAvailableShapesMessage> Out_AvailableShapes;
    }
}