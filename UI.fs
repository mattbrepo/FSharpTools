module Sofa.UI

open System
open System.Windows.Forms

/// MSGBOX
let msgbox(msg:string, caption:string) =
    let ret = MessageBox.Show(msg, caption);
    ret.ToString()

let msgbox_tuple(msg_tuple, caption:string) =
    //%%let msg = msg_tuple |> Seq.iter (fun x -> sprintf "%A\n" x)
    let msg = sprintf "%A\n" msg_tuple 
    let ret = MessageBox.Show((string)msg, caption);
    ret.ToString()

let outmsg(s:string) = Console.WriteLine(s)

let outmsg_tuple(msg_tuple) = 
    let msg = sprintf "%A\n" msg_tuple 
    outmsg(msg)

let outmsg_wait(s:string) = 
    outmsg(s)
    Console.ReadKey() |> ignore
    
//let form1 = new Form()
//form1.Text <- "... " + msg
//form1.Visible <- true