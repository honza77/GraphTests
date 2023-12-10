module MyForms.WinControls

open System.Windows
open GraphX.Common.Enums
open GraphX.Logic.Models
open GraphX.Controls
open QuickGraph
open Graph

    //let generateWpfVisuals (_zoomctrl: ZoomControl byref) (_gArea: Graph.GraphAreaExample byref) : UIElement =
let generateWpfVisuals () : ZoomControl * Graph.GraphAreaExample =
        
        
        let _zoomctrl = new ZoomControl();
        do ZoomControl.SetViewFinderVisibility(_zoomctrl, Visibility.Visible);
        let logic = new GXLogicCore<DataVertex, DataEdge, BidirectionalGraph<DataVertex, DataEdge>>();
        let _gArea =
                    let ga = new Graph.GraphAreaExample()
                    
                        // EnableWinFormsHostingMode = false,
                    ga.LogicCore <- logic
                    //ga.EdgeLabelFactory <- // TODO
                    //            let xx = (new DefaultEdgelabelFactory() :> ILabelFactory<UIElement>)
                    //            xx
                    ga
        _gArea.ShowAllEdgesLabels(true);
        logic.Graph <- 
                        //Graph.simpleExample1()  //Helpers.GenerateGraph();
                        Graph.graphExample1()
        logic.DefaultLayoutAlgorithm                <- LayoutAlgorithmTypeEnum.LinLog;
        logic.DefaultLayoutAlgorithmParams          <- logic.AlgorithmFactory.CreateLayoutParameters(LayoutAlgorithmTypeEnum.LinLog);
        //((LinLogLayoutParameters)logic.DefaultLayoutAlgorithmParams). = 100;
        logic.DefaultOverlapRemovalAlgorithm        <- OverlapRemovalAlgorithmTypeEnum.FSA;
        logic.DefaultOverlapRemovalAlgorithmParams  <- logic.AlgorithmFactory.CreateOverlapRemovalParameters(OverlapRemovalAlgorithmTypeEnum.FSA);
        //((OverlapRemovalParameters)
        logic.DefaultOverlapRemovalAlgorithmParams.HorizontalGap    <- 50f
        //((OverlapRemovalParameters)
        logic.DefaultOverlapRemovalAlgorithmParams.VerticalGap      <- 50f
        logic.DefaultEdgeRoutingAlgorithm       <- EdgeRoutingAlgorithmTypeEnum.None
        logic.AsyncAlgorithmCompute             <- false
        
        _zoomctrl.Content <- _gArea;
        //_gArea.RelayoutFinished += gArea_RelayoutFinished;


        //let myResourceDictionary = new ResourceDictionary { Source = new Uri("Templates\\template.xaml", UriKind.Relative) };
        //_zoomctrl.Resources.MergedDictionaries.Add(myResourceDictionary);

        _zoomctrl, _gArea

