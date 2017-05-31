using System.Windows;
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
        }

        private void FirstExample_Click(object sender, RoutedEventArgs e)
        {
            var graph = GraphSamples.FirstSimpleExample();
            //var graph = GraphSamples.Example2();

            var gxLogicCoreExample = new GxLogicCoreExample
            {
                Graph = Convertors.ToGraphExample(graph)
            };

            GraphArea1.LogicCore = gxLogicCoreExample;

            GraphArea1.GenerateGraph();

            ZoomCtrl.ZoomToFill();
        }

        private void OtherExample_Click(object sender, RoutedEventArgs e)
        {
            //var graphBase = GraphSamplesFactory.SimpleExample1();
            //var graphBase = GraphSamplesFactory.SimpleExample2();
            //var graphBase = GraphSamplesFactory.QuickGraphRandomGraph(vertexCount:50, edgeCount: 100);
            var graphBase = GraphSamplesFactory.CircleGraph();

            var graph = Convertors.Convert(graphBase);

            var gxLogicCoreExample = new GxLogicCoreExample
            {
                Graph = Convertors.ToGraphExample(graph)
            };

            GraphArea1.LogicCore = gxLogicCoreExample;

            GraphArea1.GenerateGraph();

            ZoomCtrl.ZoomToFill();

        }
    }
}
