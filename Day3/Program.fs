module Day3
open System

let readInput () =
    System.IO.File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Day3", "Input.txt"))

type Point =
    {
        X: int
        Y: int
    }
    member me.Move (character: char) =
        match character with
        | '^' ->
            { me with Y = me.Y + 1 }
        | 'v' ->
            { me with Y = me.Y - 1 }
        | '>' ->
            { me with X = me.X + 1 }
        | '<' ->
            { me with X = me.X - 1 }
        | _ ->
            failwithf "Unknown direction %c" character

let part1 () =
    let startingPoint = { X = 0; Y = 0 }
    let mappedLocations =
        readInput ()
        |> Seq.fold (fun (currentLocation: Point, map) nextCharacter ->
            let newLocation = currentLocation.Move nextCharacter
            let newMap = map |> Map.change newLocation (function Some value -> Some (value + 1) | None -> Some 1)
            (newLocation, newMap)
        ) (startingPoint, Map [ (startingPoint, 1) ])

    mappedLocations
    |> snd
    |> Map.count
    |> printfn "Day 3 - Part 1 - There were %i houses that received at least 1 present"

let part2 () =
    let startingPoint = { X = 0; Y = 0 }
    let mappedLocations =
        readInput ()
        |> Seq.indexed
        |> Seq.fold (fun (santaLocation: Point, roboSantaLocation: Point, map) (index, move) ->
            if index % 2 = 0 then
                let newSantaLocation = santaLocation.Move move
                let newMap = map |> Map.change newSantaLocation (function Some value -> Some (value + 1) | None -> Some 1)
                (newSantaLocation, roboSantaLocation, newMap)
            else
                let newRoboSantaLocation = roboSantaLocation.Move move
                let newMap = map |> Map.change newRoboSantaLocation (function Some value -> Some (value + 1) | None -> Some 1)
                (santaLocation, newRoboSantaLocation, newMap)
        ) (startingPoint, startingPoint, Map [ (startingPoint, 2) ])

    mappedLocations
    |> (fun (_, _, map) -> map)
    |> Map.count
    |> printfn "Day 3 - Part 2 - There were %i houses that received at least 1 present"