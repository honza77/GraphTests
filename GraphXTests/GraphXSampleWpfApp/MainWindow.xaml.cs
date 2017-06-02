using System;
using System.Windows;
using GraphX.Controls.Animations;
using GraphX.Controls.Models;
using GraphX.PCL.Common.Enums;
using GraphXSampleLib;
using GraphXSampleWpfApp.Models;

namespace GraphXSampleWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            LogirCoreSetup();
        }

        private void FirstExample_Click(object sender, RoutedEventArgs e)
        {
            var graph = GraphSamples.FirstSimpleExample();
            //var graph = GraphSamples.Example2();

            var gxLogicCoreExample = new GxLogicCoreExample
            {
                Graph = graph,
                //DefaultLayo utAlgorithm = GraphX.PCL.Common.Enums.LayoutAlgorithmTypeEnum.BoundedFR
            };

            GraphArea1.LogicCore = gxLogicCoreExample;

            GraphArea1.GenerateGraph();

            ZoomCtrl.ZoomToFill();
        }

        private void OtherExample_Click(object sender, RoutedEventArgs e)
        {
            //var graph = GraphSamplesFactory.SimpleExample1();
            //var graph = GraphSamplesFactory.SimpleExample2();
            var graph = GraphSamplesFactory.QuickGraphRandomGraph(vertexCount:25, edgeCount: 30);
            //var graph = GraphSamplesFactory.CircleGraph( vertexCount:15);
            //var graph = GraphSamplesFactory.FullGraph(vertexCount: 15);
            //var graph = GraphSamplesFactory.TreeGraph(levels:3, degree: 2);

            GraphArea1.LogicCore.Graph = Convertors.Convert(graph); 

            GraphArea1.GenerateGraph();

            ZoomCtrl.ZoomToFill();
        }

        private void Relayout_Click(object sender, RoutedEventArgs e)
        {
            if (GraphArea1.LogicCore.AsyncAlgorithmCompute)
            {
                throw new NotImplementedException();
            }

            GraphArea1.RelayoutGraph();
        }

        private void LogirCoreSetup()
        {
            var gxLogicCoreExample = new GxLogicCoreExample
            {
                DefaultLayoutAlgorithm = LayoutAlgorithmTypeEnum.BoundedFR,
                DefaultEdgeRoutingAlgorithm = EdgeRoutingAlgorithmTypeEnum.None 
            };

            //gxLogicCoreExample.Graph = GraphArea1.LogicCore?.Graph;

            GraphArea1.LogicCore = gxLogicCoreExample;

            GraphArea1.MoveAnimation = AnimationFactory.CreateMoveAnimation(MoveAnimation.Move, TimeSpan.FromSeconds(1));

            //GraphArea1.MouseOverAnimation = AnimationFactory.CreateMouseOverAnimation(MouseOverAnimation.Scale, .3);

            GraphArea1.SetVerticesDrag(true, true);
        }
    }
}
