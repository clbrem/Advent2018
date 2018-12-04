namespace ChronalCalibration
open ReadFile

module File =
    let (|StartsWith|_|) (c: char) (s: string) =
        if s.StartsWith (string c) then
            Some (s.Substring(1))
        else
            None

    let parseLine (input: string) =         
        match input with
        | StartsWith '+' rest -> int rest
        | StartsWith '-' rest -> - (int rest)
        | _ -> 0
    let sum (fileName: string) =
        let input = readLines fileName;
        let folder state item = 
            parseLine item |> (+) state
        input |> Array.fold folder 0
module Calibrate =  
    let (|HasKey|_|) key map =
        Map.tryFind key map

    type Accumulator = 
        { index: int
        ; map: Map<int, int list>
        ; shortest: int * int
        }
    
    let update (modulus: int) (A: Accumulator) (m: int) =
        { A with index = A.index+1 }


    let partialSum =
        let folder state item = (state + item, state + item)
        Array.mapFold folder 0
    
    let modulo (items: int[], modulus: int) =
        let folder (i: int, map: Map<int, int list>) (m:int) =
            let key = m % modulus;
            match map with
            | HasKey key rest -> (i+1, i :: rest |> Map.add key <| map)
            | _ -> (i+1, [i] |> Map.add key <| map)
        items 
        |> Array.fold folder (0, Map.empty)
    
    