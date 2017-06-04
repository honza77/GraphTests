using System;
using GraphXSampleDbLib.Model;


namespace GraphXSampleDbLib
{
    class GraphDbInfo
    {
        #region full DB graphs


        public static DbDataGraph GetDbModelGraph(string connString)
        {
            using (var dbInfo = new DbInfo(connString))
            {
                var tables = dbInfo.ListTableNames();
            }

            throw new NotImplementedException();
        }

        #endregion
    }
}
