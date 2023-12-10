open System
open System.Windows.Forms


let test1Run() =
    
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);    

    let win = MyForms.Form1.init()

    Application.Run win // start the event-loop

[<STAThread>]  
test1Run()