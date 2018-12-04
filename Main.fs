open System
open ChronalCalibration
[<EntryPoint>]
let main argv =
    let argList = argv |> List.ofArray
    match argList with
    | "ChronalCalibration" :: rest -> 
        if List.length rest > 0 then
            File.sum (rest.[0]) 
            |> printfn "Answer is : %i"
            0
        else
            printfn "%s" "Please supply a file"
            1
    | _ -> "Please choose an advent file" |> printfn "%s"; 1
