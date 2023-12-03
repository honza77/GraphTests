namespace MyForms

open System.Windows.Forms
open System.Drawing

open System;
open System.Linq;
open System.Windows;
open System.Windows.Forms;
open GraphX.Common.Enums;
open GraphX.Logic.Algorithms.OverlapRemoval;
open GraphX.Logic.Models;
open GraphX.Controls;
open GraphX.Controls.Models;
//open QuikGraph;
open QuickGraph

module Helpers =
    open Graph

    let generateWpfVisuals (_zoomctrl: ZoomControl byref) (_gArea: Graph.GraphAreaExample byref) : UIElement =
        _zoomctrl <- new ZoomControl();
        do ZoomControl.SetViewFinderVisibility(_zoomctrl, Visibility.Visible);
        let logic = new GXLogicCore<DataVertex, DataEdge, BidirectionalGraph<DataVertex, DataEdge>>();
        _gArea <-
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

        _zoomctrl;

    let prepareWpfHost() =
            let wpfHost = new System.Windows.Forms.Integration.ElementHost()

            wpfHost.Anchor <-     System.Windows.Forms.AnchorStyles.Top 
                              ||| System.Windows.Forms.AnchorStyles.Bottom
                              ||| System.Windows.Forms.AnchorStyles.Left
                              ||| System.Windows.Forms.AnchorStyles.Right

            wpfHost.BackColor   <- System.Drawing.Color.White;
            wpfHost.Location    <- new System.Drawing.Point(0, 0);
            wpfHost.Name        <- "wpfHost";
            wpfHost.Size        <- new System.Drawing.Size(588, 348);
            wpfHost.TabIndex    <- 0;
            wpfHost.Text        <- "elementHost1";
            wpfHost.Child       <- null;

            wpfHost


type Form1() as this =
    inherit Form()


    let wpfHost = Helpers.prepareWpfHost()

    do this.DoubleBuffered <- true

    let mutable _zoomctrl : ZoomControl = null
    let mutable _gArea : Graph.GraphAreaExample = new Graph.GraphAreaExample();
    


    let initComponents () =
        do this.SuspendLayout()

        do this.Controls.Add(wpfHost)

        //let ctrl = this :> Control
        //ctrl.DoubleBuffered     <- true
        this.Name               <- "Form1";
        this.StartPosition      <- System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text               <- "GraphX WF Interop Sample Project v1.0";
        this.ResumeLayout(false);
        ()



    //let form1_Load((sender, e)) =
    let form1_Load(xx) =
        let xxx = Helpers.generateWpfVisuals  &_zoomctrl &_gArea 
        wpfHost.Child <- xxx;

        _gArea.RelayoutFinished.Add(fun x -> _zoomctrl.ZoomToFill()) // gArea_RelayoutFinished
        _zoomctrl.ZoomToFill()
        _gArea.GenerateGraph(true);
        _gArea.SetVerticesDrag(true, true);
        _zoomctrl.ZoomToFill();
        ()

    do initComponents () 
    do this.Load.Add(form1_Load)

    
    



