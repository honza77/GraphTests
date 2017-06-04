using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GraphXSampleDbLib
{
    class DbInfo : IDisposable
    {
        private readonly SqlConnection _connection;

        public DbInfo(string connString)
        {
            _connection = new SqlConnection(connString);
            _connection.Open();
        }

        public IEnumerable<string> ListTableNames()
        {
            DataTable dt = _connection.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                yield return (string)row[2];
            }
        }

        public IEnumerable<Tuple<string, string>> ReadAllFKs()
        {
            var tables = ListTableNames(); 

            foreach (var table1 in tables)
            {
                var fks = ReadTableFKs(table1);

                foreach (var table2 in fks)
                {
                    yield return Tuple.Create(table1, table2);
                }
            }
        }

        public IEnumerable<string> ReadTableFKs(string tableName)
        {
            using (SqlCommand cmd = new SqlCommand("sp_fkeys", _connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pktable_name", tableName));

                var rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    yield return rdr["FKTABLE_NAME"].ToString();
                }

                rdr.Close();
            }
        }

        #region IDisposable Support
        private bool _disposedValue; //  = false .. To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _connection.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                _disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~DbInfo() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
