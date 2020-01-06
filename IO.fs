module Sofa.IO

open System
open System.IO

/// WRITE FILE DI TESTO
let write_file_txt (file: string, data: string) =
    File.WriteAllText(file, data)

/// GET FILE IN DIRECTORY CON PATTERN
let get_files dir pattern  = Directory.GetFiles(dir, pattern)
let get_all_files dir pattern  = Directory.GetFiles(dir, pattern, SearchOption.AllDirectories)

/// GET FILE IN DIRECTORY CON PATTERN RICORSIVA
//%%let rec getRecFiles dir pattern = 

/// IMPORT FILE CSV IN UN'ARRAY DI TUPLE
let read_csv file separator (jumpline: int) = 
    let lines = File.ReadAllLines(file)
    //let tuples = lines |> Array.map (fun x -> x.Split [| separator |])
    let tuples = Array.sub lines jumpline (lines.Length - jumpline) |> Array.map (fun x -> x.Split [| separator |])
    tuples

let read_file (file:string) = seq { 
    use reader = new StreamReader(file)
    while not reader.EndOfStream do yield reader.ReadLine() 
}

/// %%%%%
type 'a SearchResult(lineNo:int,file:string,content:'a) =
    member this.LineNo = lineNo
    member this.File = file
    member this.Content = content
    override this.ToString() =
        sprintf "line %d in %s – %O" this.LineNo this.File this.Content

let search_file parse check file =
    read_file file
    |> Seq.mapi (fun i l -> i + 1, parse l)
    |> Seq.filter check
    |> Seq.map (fun (i, l) -> SearchResult(i,  file, l))

let search_file_fun parse check =
    Seq.map (fun file -> search_file parse check file)
    >> Seq.concat

let print_results<'a> : 'a SearchResult seq -> unit =
    Seq.fold (fun c r -> printfn "%O" r; c + 1) 0
    >> printfn "%d results"


///
///    Directory.GetFiles(@"c:\_src\", "*.cs", SearchOption.AllDirectories)
///    |> search_file_fun id (fun (i, l) -> l.Contains("public void Test"))
///    |> print_results
///

/// %%%%%