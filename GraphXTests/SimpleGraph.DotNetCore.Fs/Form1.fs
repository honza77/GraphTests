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

    let initComponents (this:Form) =
        //let ctrl = this :> Control
        //ctrl.DoubleBuffered     <- true
        this.Name               <- "Form1";
        this.StartPosition      <- System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text               <- "GraphX WF Interop Sample Project v1.0";




type Form1() as this =
    inherit Form()

    do this.DoubleBuffered <- true  // is this usefull ?


    
module Form1 =

    let initComponents (frm:Form) (wpfHost)=
        do frm.SuspendLayout()
        do frm.Controls.Add(wpfHost)
        Helpers.initComponents frm
        frm.ResumeLayout(false)

    let form1_Load(wpfHost:Integration.ElementHost) =
        let _zoomctrl , _gArea = WinControls.generateWpfVisuals  ()
        wpfHost.Child <- _zoomctrl

        _gArea.RelayoutFinished.Add(fun x -> _zoomctrl.ZoomToFill()) // gArea_RelayoutFinished
        _zoomctrl.ZoomToFill()
        _gArea.GenerateGraph(true);
        _gArea.SetVerticesDrag(true, true);
        _zoomctrl.ZoomToFill();
        ()


    let init () =

        let frm = new Form1()

        let wpfHost = Helpers.prepareWpfHost()
        

        //let mutable _zoomctrl : ZoomControl = null
        let  _gArea : Graph.GraphAreaExample = new Graph.GraphAreaExample();

        do initComponents frm wpfHost 
        do frm.Load.Add(fun _ -> form1_Load wpfHost)


        frm
    



