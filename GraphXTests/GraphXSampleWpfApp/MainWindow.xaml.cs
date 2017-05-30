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
            var graphBase = GraphSamplesFactory.FirstSimpleExample();

            var graph = Convertors.Convert(graphBase);

            var gxLogicCoreExample = new GxLogicCoreExample
            {
                Graph = Convertors.ToGraphExample(graph)
            };

            GraphArea1.LogicCore = gxLogicCoreExample;

            GraphArea1.GenerateGraph();

            //ZoomCtrl.ZoomToFill();
        }
    }
}
