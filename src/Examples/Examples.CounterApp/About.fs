namespace Examples.CounterApp

module About =
    open Avalonia.Controls
    open Avalonia.Media.Imaging
    open Avalonia.FuncUI.DSL
    open Avalonia.FuncUI.Components
    open Avalonia.FuncUI.Elmish
    open Elmish
    open Avalonia.FuncUI.Builder
    open Avalonia.Layout
    open Avalonia.FuncUI.Types

    type Props = {
        Message: string
    } 

    type Model =
        { Message: string }

    type Msg =
        | DoSomething

    let init (props: Props) =
        { Message = props.Message }, Cmd.none

    let update (msg: Msg) (model: Model) : Model * Cmd<_> =
        match msg with
        | DoSomething -> model, Cmd.none

    let view (model: Model) dispatch =
        StackPanel.create [
            StackPanel.children [

                TextBlock.create [
                    TextBlock.text model.Message
                ]
            ]
        ]


    type Host(props) as this =
        inherit Hosts.HostControl()
        do
            /// You can use `.mkProgram` to pass Commands around
            /// if you decide to use it, you have to also return a Command in the initFn
            /// (init, Cmd.none)
            /// you can learn more at https://elmish.github.io/elmish/basics.html
            let startFn () =
                init props
            Elmish.Program.mkProgram startFn update view
            |> Program.withHost this
            |> Program.run
