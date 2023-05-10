(* ======================================
FPTurtleLib.fsx

Part of "Thirteen ways of looking at a turtle"
Related blog post: http://fsharpforfunandprofit.com/posts/13-ways-of-looking-at-a-turtle/
======================================
*)

open System

type Distance = float
type [<Measure>] Degrees
type Angle  = float<Degrees>
type Position = {x: Distance; y: Distance}



module Turtle =

    type TurtleState = {
        Position : Position
        Angle : float<Degrees>
    }

    let initialTurtleState = {
        Position = {x=0.0; y=0.0}
        Angle = 0.0<Degrees>
    }

    let private round2 (flt:float) = Math.Round(flt,2)

    let private calcNewPosition (distance:Distance) (angle:Angle) currentPos =
        let angleInRads = angle * (Math.PI/180.0<Degrees>)
        let offsetUsing start fn = start + (distance * fn angleInRads)
        let x = offsetUsing currentPos.x cos
        let y = offsetUsing currentPos.y sin
        {x=round2 x; y=round2 y}


    let private dummyDrawLine log oldPos newPos =
        log (sprintf "...Draw line from (%0.1f,%0.1f) to (%0.1f,%0.1f)" oldPos.x oldPos.y newPos.x newPos.y)

    let move log distance state =
        log (sprintf "Move %0.1f" distance)
        let newPosition = calcNewPosition distance state.Angle state.Position
        dummyDrawLine log state.Position newPosition
        {state with Position = newPosition}

    let turn log angle state =
        log (sprintf "Turn %0.1f" angle)
        let newAngle = (state.Angle + angle) % 360.0<Degrees>
        {state with Angle = newAngle}


//////////////////// driver ///////////////////////////////////////
///

let log = printfn "%s"

let debug x =
    printfn "%A" x
    x

[<EntryPoint>]
let main argv =
    let move = Turtle.move log

    let finalState =
        Turtle.initialTurtleState
        |> debug
        |> move 100.0
        |> debug
        |> Turtle.turn log 120.0<Degrees>
        |> debug
        |> Turtle.move log 100.0
        |> debug
        |> Turtle.turn log 120.0<Degrees>
        |> debug
        |> Turtle.move log 100.0
        |> debug
        |> Turtle.turn log 120.0<Degrees>
    0 // return an integer exit code
