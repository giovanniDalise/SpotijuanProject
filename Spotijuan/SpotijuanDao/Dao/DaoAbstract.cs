using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using Spotijuan.Dao.Exceptions;
using System.Configuration;
using System.Data;
using System.Reflection.PortableExecutable;

namespace Spotijuan.Dao.Dao
{
    public abstract class DaoAbstract<T> : IDao<T>
    {
        string connectionString = ConfigurationManager.ConnectionStrings["SPOTIJUAN"].ConnectionString;

        private OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }

        public List<T> Read()
        {
            return ExecuteQuery(GetSelect());
        }
    /*  
        public List<T> FindByText(string text)
        {
            return ExecuteQueryByText(GetFindByText(),text);
        }
      
        public List<T> FindByObject(T element)
        {
            return ExecuteQueryByObject(GetFindByObject(element));
        }
       
        public T FindById(int id)
        {
            return ExecuteQueryById(GetFindById(), id);
        }
     */  
        private List<T> ExecuteQuery(string storedProcedureName)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Output parameter
                        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        cmd.Parameters["p_cursor"].Direction = ParameterDirection.Output;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            return TransformData(reader);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                throw new DaoException("Errore durante la lettura degli utenti dal database.", ex);
            }
        }
    /*  
        private T ExecuteQueryById(string storedProcedureName, int id)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Output parameter
                        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        cmd.Parameters["p_cursor"].Direction = ParameterDirection.Output;

                        // Input parameter
                        string paramName = GetIdName();
                        cmd.Parameters.Add(paramName, OracleDbType.Int32).Value = id;
                        cmd.Parameters[paramName].Direction = ParameterDirection.Input;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            List<T> result = TransformData(reader);
                            return result.Count > 0 ? result[0] : default(T);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                throw new DaoException("Errore durante la lettura dei dati dal database.", ex);
            }
        }
        private List<T> ExecuteQueryByObject(string directQuery)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(directQuery, conn))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            return TransformData(reader);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                throw new DaoException("Errore durante l'esecuzione della query diretta.", ex);
            }
        }
        private List<T> ExecuteQueryByText(string storedProcedureName, string text)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Output parameter
                        cmd.Parameters.Add("p_cursor", OracleDbType.RefCursor);
                        cmd.Parameters["p_cursor"].Direction = ParameterDirection.Output;

                        // Input parameter
                        cmd.Parameters.Add("p_text", OracleDbType.Varchar2).Value = text;
                        cmd.Parameters["p_text"].Direction = ParameterDirection.Input;

                        cmd.BindByName = true;

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            return TransformData(reader);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                throw new DaoException("Errore durante la lettura dei dati dal database.", ex);
            }
        }
         
        public int Create(T item)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();

                    string idName = GetIdName();
                    using (OracleCommand cmd = new OracleCommand(GetInsert(item) + $" RETURNING {idName} INTO :idOutParam", conn))
                    {
                        cmd.Parameters.Add("idOutParam", OracleDbType.Int32, ParameterDirection.ReturnValue);

                        cmd.ExecuteNonQuery();

                        int result = ((OracleDecimal)cmd.Parameters["idOutParam"].Value).ToInt32();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eccezione durante la lettura dei dati dal database: {ex.GetType().Name} - {ex.Message}");
                throw new DaoException("Errore durante la lettura dei dati dal database.", ex);
            }
        }
        
        public void Update(T item, int id)
        {
            string[] queries = GetUpdate(item, id).Split(';');
            foreach (string query in queries)
            {
                Update(query);
            }
        }
       
        private void Update(string updateQuery)
        {
            try
            {
                using (OracleConnection conn = GetConnection())
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand(updateQuery, conn))
                    {
                            cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (OracleException ex)
            {
                throw new DaoException("Errore durante l'aggiornamento nella tabella.", ex);
            }
        }
       
        public void Delete(int id)
             {
                 string[] queries = GetDelete(id).Split(';');
                 foreach (string query in queries)
                 {
                     Update(query);
                 }
             }
     */    
        protected virtual List<T> TransformData(OracleDataReader reader)
        {
            List<T> result = new List<T>();
            try
            {
                while (reader.Read())
                {
                    result.Add(ResultsetToEntity(reader));
                }
            }
            catch (OracleException ex)
            {
                throw new DaoException("Errore in fase di trasformazione dei dati.", ex);
            }
            return result;
        }
        //Da ResultSet a singolo elemento o entità
        protected abstract T ResultsetToEntity(OracleDataReader reader);

        protected abstract string GetSelect();
        /* 
        protected abstract string GetDelete(int id); 
        protected abstract string GetUpdate(T item,int id);
        protected abstract string GetInsert(T item);
        protected abstract string GetIdName();       
        protected abstract string GetFindById();
        protected abstract string GetFindByObject(T Object);
        protected abstract string GetFindByText();
          */
    }
}
