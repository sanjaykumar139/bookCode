using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Oracle.ManagedDataAccess.Client;

namespace ConsoleApp1.ConnPool
{
    class connpooltesting
    {
        public static void MainQrr(string[] args)
        {
            //ORACLE SERVER
            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=izendanorthwind.crhgcm4msm7l.ap-southeast-1.rds.amazonaws.com)(PORT=1521))(CONNECT_DATA=(SID=IZNORTHW)));User Id=MyUserSanjay3120;Password=MyUserSanjay3120;";
            
            OracleConnection connectionn = new OracleConnection();
            OracleConnection connectionn1 = new OracleConnection();
            OracleConnection connectionn2 = new OracleConnection();
            OracleConnection connectionn3 = new OracleConnection();
            OracleConnection connectionn4 = new OracleConnection();
            OracleConnection connectionn5 = new OracleConnection();
            OracleConnection connectionn6 = new OracleConnection();
            OracleConnection connectionn7 = new OracleConnection();
            OracleConnection connectionn8 = new OracleConnection();
            OracleConnection connectionn9 = new OracleConnection();

            connectionn.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=2";
            connectionn1.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=2";
            connectionn2.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;" +"Incr Pool Size=5; Decr Pool Size=1";
            connectionn3.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=1";
            connectionn4.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=2";
            connectionn5.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=2";
            connectionn6.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=2";
            connectionn7.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=2";
            connectionn8.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=2";
            connectionn9.ConnectionString = connectionString + "Min Pool Size=0;Max Pool Size=3;Connection Lifetime=100000;Connection Timeout=30;";// +"Incr Pool Size=5; Decr Pool Size=2";

            connectionn.Open(); 
            Console.WriteLine("Connected to Oracle " + connectionn.ServerVersion);

            connectionn1.Open();
            connectionn2.Open();
            connectionn3.Open();
            connectionn4.Open();
            connectionn5.Open();
            connectionn6.Open();
            connectionn7.Open();
            connectionn8.Open();
            connectionn9.Open();

            connectionn.Close();
            connectionn1.Close();
            connectionn2.Close();
            connectionn3.Close();
            connectionn4.Close();
            connectionn5.Close();
            connectionn6.Close();
            connectionn7.Close();
            connectionn8.Close();
            connectionn9.Close();

            //SQL SERVER
            string sqlConnectString = "Data Source=DESKTOP-AC0PP7M;Initial Catalog=IzConfig3.11.4.3;User ID=sa;Password=admin123;";
            string sqlConnectString1 = "Data Source=DESKTOP-AC0PP7M;Initial Catalog=IzConfig3.11.4;User ID=sa;Password=admin123;";

            SqlConnection connection = new SqlConnection();
            SqlConnection connection1 = new SqlConnection();
            SqlConnection connection2 = new SqlConnection();
            SqlConnection connection3 = new SqlConnection();
            SqlConnection connection4 = new SqlConnection();

            // Set the connection string with pooling option    
            connection.ConnectionString = sqlConnectString + "Connection Timeout=10;Connection Lifetime=0;Min Pool Size=0;Max Pool Size=3;Pooling=true;";
            connection1.ConnectionString = sqlConnectString1 + "Connection Timeout=10;Connection Lifetime=0;Min Pool Size=0;Max Pool Size=3;Pooling=true;";
            connection2.ConnectionString = sqlConnectString + "Connection Timeout=10;Connection Lifetime=0;Min Pool Size=0;Max Pool Size=3;Pooling=true;";
            connection3.ConnectionString = sqlConnectString + "Connection Timeout=10;Connection Lifetime=0;Min Pool Size=0;Max Pool Size=3;Pooling=true;";
            connection4.ConnectionString = sqlConnectString + "Connection Timeout=10;Connection Lifetime=0;Min Pool Size=0;Max Pool Size=3;Pooling=true;";

            connection.Open();
            connection1.Open();
            connection2.Open();
            connection3.Open();
            connection4.Open();

            connection.Close();
            connection1.Close();
            connection2.Close();
            connection3.Close();
            connection4.Close();
        }

        public static void Testing()
        {

            using (SqlConnection con = new SqlConnection("Data Source=Suresh;Integrated security=SSPI;Initial Catalog=SampleDB"))
            {
                con.Open();
                // Connection Pool A will be created.
            }
            using (SqlConnection con = new SqlConnection("Data Source=Suresh;Integrated security=SSPI;Initial Catalog=aspdotnetDB"))
            {
                con.Open();
                // Separate connection pool B will create because connection string different.
            }
            using (SqlConnection con = new SqlConnection("Data Source=Suresh;Initial Catalog=aspdotnetdb;Pooling=false;"))
            {
                con.Open();
                // No connection pool will create because we defined Pooling = false.
            }
            using (SqlConnection con = new SqlConnection("Data Source=Suresh;Integrated security=SSPI;Initial Catalog=SampleDB"))
            {
                con.Open();
                // This connection string matches with Connection Pool A.
            }
        }
    }

    //static public uint uNonQuery(string query)
    //{

    //    using (Connection = new MySqlConnection(ConnectionString))
    //    {
    //        if (Connection.State == ConnectionState.Open)
    //        {
    //            Console.WriteLine("Its open..>!!!!");
    //        }

    //        Connection.Open();

    //        MySqlCommand cmd = new MySqlCommand(query, Connection);
    //        cmd.ExecuteNonQuery();


    //        MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT LAST_INSERT_ID() AS 'identity'", Connection);
    //        DataTable dt = new DataTable();
    //        adapter.Fill(dt);
    //        uint ret = 0;

    //        if (dt.Rows.Count > 0)
    //        {
    //            try
    //            {
    //                ret = Convert.ToUInt32(dt.Rows[0]["identity"]);
    //            }
    //            catch
    //            {
    //                ret = 0;
    //            }
    //        }

    //        else
    //            ret = 0;

    //        Connection.Close();
    //        return ret;
    //    }
    //}
    //static void DoInserts(object o)
    //{
    //    int i = (int)o;
    //    Console.WriteLine("Insert Thread {0} launched", i);


    //    for (int x = 0; x < 1000; x++)
    //    {
    //        uint insertId = DataLayer.uNonQuery(String.Format("INSERT INTO testdb.dbtest (writeNo,strNo) VALUES ({0},'x={0} thread={1}')", x, i));
    //    }

    //    Console.WriteLine("Insert Thread {0} completed", i);

    //}

    //DbProviderFactory Factory = DbProviderFactories.GetFactory("DDTek.Oracle");
    //DbConnection Conn1 = Factory.CreateConnection();
    //Conn1.ConnectionString = "Host=Accounting;Port=1521;User ID=scott;Password=tiger; " +  "Service Name=ORCL;Min Pool Size=50";
    //        Conn1.Open();

    //        // Pool A is created and filled with connections to the
    //        // minimum pool size
    //        DbConnection Conn2 = Factory.CreateConnection();
    //Conn2.ConnectionString = "Host=Accounting;Port=1521;User ID=Jack;Password=quake; " + "Service Name=ORCL;Min Pool Size=100";
    //        Conn2.Open();

    //        // Pool B is created because the connections strings differ
    //        DbConnection Conn3 = Factory.CreateConnection();
    //Conn3.ConnectionString = "Host=Accounting;Port=1521;User ID=scott;Password=tiger; " +"Service Name=ORCL;Min Pool Size=50";
    //        Conn3.Open();
    //        // Conn3 is assigned an existing connection that was created in
    //        // Pool A when the pool was created for Conn1
}
