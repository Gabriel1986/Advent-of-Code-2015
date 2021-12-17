module Day2
open System

let readInput () =
    System.IO.File.ReadAllLines(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Day2", "Input.txt"))
    |> Array.map (fun each ->
        each.Split("x")
        |> Array.map Int32.Parse
        |> (function [| l; w; h |] ->  l, w, h | _ -> failwithf "Invalid dimensions"))

let part1 () =
    let calculateRequiredPackingPaperArea (l, w, h) =
        let smallestDimensions = [ l; w; h ] |> List.sort |> List.take 2
        2 * l * w + 2 * w * h + 2 * l * h + smallestDimensions[0] * smallestDimensions[1]

    readInput ()
    |> Seq.sumBy calculateRequiredPackingPaperArea
    |> printfn "Day 2 - Part 1 - Surface area: %i"

let part2 () =
    let calculateBowLength (l, w, h) =
        let smallestDimensions = [ l; w; h ] |> List.sort |> List.take 2
        smallestDimensions[0] * 2 + smallestDimensions[1] * 2 + l * w * h

    readInput ()
    |> Seq.sumBy calculateBowLength
    |> printfn "Day 2 - Part 2 - Bow length: %i"