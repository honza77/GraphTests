using GraphX.PCL.Common.Models;

namespace GraphXSampleDbLib.Model
{
    class DbDataVertex : VertexBase
    {
        /// <summary>
        /// Some string property for example purposes
        /// </summary>
        public string TableName { get; set; }

        #region Calculated or static props

        public override string ToString()
        {
            return TableName;
        }

        #endregion

        /// <summary>
        /// Default parameterless constructor for this class
        /// (required for YAXLib serialization)
        /// </summary>
        public DbDataVertex() : this(string.Empty)
        {
        }

        public DbDataVertex(string tableName = "")
        {
            TableName = tableName;
        }

    }
}
