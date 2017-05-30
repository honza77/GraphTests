using GraphX.PCL.Logic.Models;
using QuickGraph;

namespace GraphXSampleWpfApp.Models
{
    //public class GxLogicCoreExample : GXLogicCore<DataVertex, DataEdge, GraphExample> { }
    public class GxLogicCoreExample : GXLogicCore<DataVertex, DataEdge, BidirectionalGraph<DataVertex, DataEdge>> { }
}
