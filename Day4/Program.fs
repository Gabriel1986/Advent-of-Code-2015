module Day4
open System

let [<Literal>] input = "iwrupvqb"

let part1 () =
    seq { 0..Int32.MaxValue }
    |> Seq.find (fun i ->
        MD5Hash.Hash.Content(input + string i)
        |> Seq.take 5
        |> Seq.forall (fun b -> b.Equals('0'))
    )
    |> printfn "Day 3 - Part 1 - Found number %i"

let part2 () =
    seq { 0..Int32.MaxValue }
    |> Seq.find (fun i ->
        MD5Hash.Hash.Content(input + string i)
        |> Seq.take 6
        |> Seq.forall (fun b -> b.Equals('0'))
    )
    |> printfn "Day 3 - Part 2 - Found number %i"