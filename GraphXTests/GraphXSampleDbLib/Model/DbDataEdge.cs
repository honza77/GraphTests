using GraphX.PCL.Common.Models;

namespace GraphXSampleDbLib.Model
{
    public class DbDataEdge : EdgeBase<DbDataVertex>
    {
        /// <summary>
        /// Default constructor. We need to set at least Source and Target properties of the edge.
        /// </summary>
        /// <param name="source">Source vertex data</param>
        /// <param name="target">Target vertex data</param>
        /// <param name="weight">Optional edge weight</param>
        public DbDataEdge(DbDataVertex source, DbDataVertex target, double weight = 1) : base(source, target, weight)
        {
        }

        /// <summary>
        /// Default parameterless constructor (for serialization compatibility)
        /// </summary>
        public DbDataEdge() : base(null, null)
        {
        }

        /// <summary>
        /// Custom string property for example
        /// </summary>
        public string FkName { get; set; }

        public override string ToString()
        {
            return FkName;
        }
    }
}
