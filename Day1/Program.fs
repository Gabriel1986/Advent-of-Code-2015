module Day1

let readInput () =
    System.IO.File.ReadAllText(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Day1", "Input.txt"))

let characterMap = Map [
    '(', 1
    ')', -1
]
let mapCharacter (character: char) = characterMap[character]

let part1 () =
    readInput()
    |> Seq.sumBy mapCharacter
    |> printfn "Day 1 - Part 1 - Santa needs to go to floor %i"

// Taking advantage that sequences are lazy, find will only calculate the sequence until it reaches the first hit
let part2 () =
    let input = readInput ()

    seq {
        let mutable currentFloor = 0
        for i in 0..input.Length-1 do
            currentFloor <- currentFloor + mapCharacter (input[i])
            yield (i + 1, currentFloor)
    }
    |> Seq.find (fun (_, floor) -> floor = -1)
    |> fst
    |> printfn "Day 1 - Part 2 - The first basement index is %i"
