// Learn more about F# at http://fsharp.org

open System

type Displacement = float
type Pos = { x: Displacement; y: Displacement }
type [<Measure>] Degrees

type Angle = float<Degrees>

type TurtleState = {
    Position: Pos
    Angle: Angle
}

let myTurtle : TurtleState = {
    Position = { x= 0.0; y= 0.0 }
    Angle = 180.0<Degrees>
}

let turn angle state =
    let newAngle = (state.Angle + angle) % 360.0<Degrees>
    { state with Angle = newAngle }

let move distance state =
    let radians = state.Angle * (Math.PI/180.0<Degrees>)
    let offset pos fn = pos + distance * (fn radians)
    let x = offset state.Position.x cos
    let y = offset state.Position.y sin
    { state with Position = { x= x; y= y }}

let debug turtle =
  printfn "%A" turtle
  turtle


let run =
    let finalState =
      myTurtle
      |> turn 90.0<Degrees>
      |> move 100.0
      |> debug
      |> turn 90.0<Degrees>
      |> move 100.0

    debug finalState
