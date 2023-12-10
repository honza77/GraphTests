namespace MyForms

open System.Windows.Forms
//open System.Drawing

//open System;
//open System.Linq;
//open System.Windows;
//open System.Windows.Forms;
//open GraphX.Common.Enums;
//open GraphX.Logic.Algorithms.OverlapRemoval;
//open GraphX.Logic.Models;
//open GraphX.Controls;
//open GraphX.Controls.Models;
////open QuikGraph;
//open QuickGraph





type Form1() as this =
    inherit Form()

    do this.DoubleBuffered <- true  // is this usefull ?


    
module Form1 =


    let prepareWpfHost() =
            let wpfHost = new System.Windows.Forms.Integration.ElementHost()

            wpfHost.Anchor <-     System.Windows.Forms.AnchorStyles.Top 
                              //||| System.Windows.Forms.AnchorStyles.Bottom
                              ||| System.Windows.Forms.AnchorStyles.Left
                              //||| System.Windows.Forms.AnchorStyles.Right

            wpfHost.BackColor   <- System.Drawing.Color.White
            wpfHost.Location    <- new System.Drawing.Point(100, 100)
            wpfHost.Name        <- "wpfHost"
            wpfHost.Size        <- new System.Drawing.Size(1100, 500)
            wpfHost.TabIndex    <- 0
            wpfHost.Text        <- "elementHost1"
            wpfHost.Child       <- null

            wpfHost

    let initComponentsSettings (this:Form) =
        //let ctrl = this :> Control
        //ctrl.DoubleBuffered     <- true
        this.Name               <- "Form1";
        this.StartPosition      <- System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text               <- "GraphX WF Interop Sample Project v1.0";

    let initComponents (frm:Form) (wpfHost)=
        do frm.SuspendLayout()
        do frm.Controls.Add(wpfHost)
        initComponentsSettings frm
        frm.ResumeLayout(false)

    let prepareArea () =
        let _zoomctrl , _gArea = WinControls.generateWpfVisuals  ()

        _gArea.RelayoutFinished.Add(fun x -> _zoomctrl.ZoomToFill()) // gArea_RelayoutFinished
        _zoomctrl.ZoomToFill()
        _gArea.GenerateGraph(true)
        _gArea.SetVerticesDrag(true, true)
        _zoomctrl.ZoomToFill()
        _zoomctrl


    let form1_Load(wpfHost:Integration.ElementHost) =
        let _zoomctrl = prepareArea () 
        wpfHost.Child <- _zoomctrl
        ()


    open System.Drawing

    let drawing_test1 (gr : Graphics)  = 

    
        let pinkPen = new Pen(Color.Pink)

        //for a=0 to 4 do
        //    let a2 = a * 24
        //    //let pen = new Pen(new Color(20))
        //    

        for i=0 to 10 do
            let a2 = i * 24
            use brush = new SolidBrush(Color.FromArgb(255, a2, a2, a2))
            let j = i * 50
            let velikost = i * 140
            //gr.DrawEllipse(pinkPen, 750, 650-a2, 200+velikost, 200+velikost)
            gr.FillEllipse(brush, 950, 550-i, 800-velikost, 800-velikost)

    let init () =

        let frm = new Form1()

        let wpfHost = prepareWpfHost()

        //let mutable _zoomctrl : ZoomControl = null
        let  _gArea : Graph.GraphAreaExample = new Graph.GraphAreaExample();

        do initComponents frm wpfHost 
        form1_Load wpfHost
        //do frm.Load.Add(fun _ -> form1_Load wpfHost)

        frm.ClientSize <- System.Drawing.Size (1500, 1200)
        //frm.BackColor <- Color.Black
        //frm.Paint.Add(fun pea -> drawing_test1 pea.Graphics)
        frm
    



