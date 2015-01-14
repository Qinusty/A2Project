using Microsoft.VisualBasic;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;

namespace A2_Project
{
    public class AccessHelper
    {
        public static string connectionString;

        static AccessHelper()
        { 
            //for the jet 4 connection to work
            //the project has to be built as a 32bit application
            //select 'build', 'configuration manager' and change platform to x86
            
            //Access connection string
            SetConnectionString("|datadirectory|MyDB.accdb");
        }
         

        public static int ExecuteNonQuery(string sql, OleDbParameter[] args = null)
        {
            SetConnectionString("|datadirectory|MyDB.accdb");
            OleDbConnection cnn = new OleDbConnection(connectionString);

            OleDbCommand cmd = new OleDbCommand(sql, cnn);
            if (args != null)
            {
                for (int i = 0; i < args.Length - 1; i++)
                {
                    cmd.Parameters.Add(args[i]);
                }
            }
            cnn.Open();
            int retVal = cmd.ExecuteNonQuery();
            cnn.Close();

            return retVal;
        }
        

        public static DataSet ExecuteDataSet(string sql, string dataMemberName)
        {
            SetConnectionString("|datadirectory|MyDB.accdb");
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, connectionString);
            
            da.Fill(ds, dataMemberName);

            return ds;
        }

        public static DataSet ExecuteDataSet(string sql, OleDbParameter[] args)
        {
            SetConnectionString("|datadirectory|MyDB.accdb");
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(sql, connectionString);

            for (int i = 0; i < args.Length - 1; i++)
            {
                da.SelectCommand.Parameters.Add(args[i]);
            }
            da.Fill(ds);
            return ds;
        }
        static void SetConnectionString(string DatabasePath)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder();
            builder["Provider"] = "Microsoft.ACE.OLEDB.12.0";

            builder["Data Source"] = DatabasePath;

            connectionString = builder.ConnectionString;
        }
        public static string HashPassword(string _password)
        {
            UnicodeEncoding uniEncode = new UnicodeEncoding();
            
            byte[] message = uniEncode.GetBytes(_password);

            SHA512Managed hashString = new SHA512Managed();
            string retVal = "";

            byte[] hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                retVal += string.Format("{0:x2}", x);
            }
            return retVal;
        }
    }
}
