using GraphX.PCL.Common.Models;

namespace GraphXSampleDbLib.Model
{
    public class DbDataVertex : VertexBase
    {
        /// <summary>
        /// Some string property for example purposes
        /// </summary>
        public string TableName { get; set; }

        public string TableOwner { get; set; }

        #region Calculated or static props

        public override string ToString()
        {
            //return TableName;
            return $"{TableOwner}.{TableName}";
        }

        #endregion

        /// <summary>
        /// Default parameterless constructor for this class
        /// (required for YAXLib serialization)
        /// </summary>
        public DbDataVertex() : this(string.Empty, string.Empty)
        {
        }

        public DbDataVertex(string tableName) : this(string.Empty, tableName)
        {
        }

        public DbDataVertex(string tableOwner, string tableName)
        {
            TableName = tableName;
            TableOwner = tableOwner;
        }

    }
}
