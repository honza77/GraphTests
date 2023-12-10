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



let test1Run() =
    
    //test1 win

    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);    
    let win = 
        //new Form () 
        //new MyForms.Form1()
        MyForms.Form1.init()

    win.ClientSize <- System.Drawing.Size (500, 500)
    Application.Run win // start the event-loop

[<STAThread>]  
test1Run()