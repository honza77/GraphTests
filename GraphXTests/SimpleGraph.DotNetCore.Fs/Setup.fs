module Setup

open GraphX.Common.Enums
open GraphX.Controls.Models
open GraphX.Controls.Animations
open Graph


let logicCore1 = 
    let lc = new GxLogicCoreExample()
    lc.DefaultLayoutAlgorithm <- LayoutAlgorithmTypeEnum.BoundedFR
    lc.DefaultEdgeRoutingAlgorithm <- EdgeRoutingAlgorithmTypeEnum.None //.PathFinder, //.None 
    //DefaultOverlapRemovalAlgorithm = OverlapRemovalAlgorithmTypeEnum.FSA
    lc

let SetupGraphArea (ga:GraphAreaExample) =
    ga.LogicCore <- logicCore1
    ga.MoveAnimation <- AnimationFactory.CreateMoveAnimation(MoveAnimation.Move, (System.TimeSpan.FromSeconds 1.0))
    ga.SetVerticesDrag(true, true)
    ()

let setGraphToArea (ga:GraphAreaExample) (g:GraphExample) =
    logicCore1.Graph <- g
    ga.LogicCore <- logicCore1
    ()