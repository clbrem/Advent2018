namespace ChronalCalibration
open ReadFile

module Calibrate =
    let (|StartsWith|_|) (c: char) (s: string) =
        if s.StartsWith (string c) then
            Some (s.Substring(1))
        else
            None
    let sum = Array.sum<int>
    let parseLine (input: string) =         
        match input with
        | StartsWith '+' rest -> int rest
        | StartsWith '-' rest -> - (int rest)
        | _ -> 0
    let file (fileName: string) =
        let input = readLines fileName;
        let folder state item = 
            parseLine item |> (+) state
        input |> Array.fold folder 0
    