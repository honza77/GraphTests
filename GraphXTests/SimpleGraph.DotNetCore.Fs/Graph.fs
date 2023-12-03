module Graph

//open QuikGraph
open QuickGraph
//open FsXamlApp.Models

let simpleExample1() =
    let graph = new BidirectionalGraph<int, IEdge<int>>()

    graph.AddVertex(1) |> ignore
    graph.AddVertex(2) |> ignore

    let edge1 = new Edge<int>(1, 2)
    graph.AddEdge(edge1) |> ignore
    graph


// ------------------------

open GraphX.Common.Models
open GraphX.Controls
open GraphX.Logic.Models

type DataVertex(text:string) =
    inherit VertexBase()

    member x.Text = text
    override x.ToString() = x.Text
    
type DataEdge(source, target) =
    inherit EdgeBase<DataVertex>(source, target, 1.0)

type GraphAreaExample() =
    inherit GraphArea<DataVertex, DataEdge, BidirectionalGraph<DataVertex, DataEdge>>() 

type GraphExample() =
    inherit BidirectionalGraph<DataVertex, DataEdge>()

type GxLogicCoreExample() =
    inherit GXLogicCore<DataVertex, DataEdge, BidirectionalGraph<DataVertex, DataEdge>>()


let graphExample1() =
    let graph = new GraphExample()

    // 1. add vertexes
    let v1 = new DataVertex("1");
    let v2 = new DataVertex("2");

    graph.AddVertex(v1) |> ignore
    graph.AddVertex(v2) |> ignore

    let edge1 = new DataEdge(v1, v2)
    graph.AddEdge(edge1) |> ignore
    graph



