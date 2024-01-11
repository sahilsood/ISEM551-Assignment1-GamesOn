using System.Data;
using System.Data.SqlClient;

namespace DataAccess;

public class DAGameOn
{
        //Get the Top Played Games data by NOT USING the database
        public static DataSet GetTopPlayedWithOutDB()
        {
            
            DataSet report = new DataSet();

            report.DataSetName = "GamesOn";
            DataTable dt = new DataTable("TopPlayed");
            dt.Clear();
            dt.Columns.Add(new DataColumn("Title", typeof(string)));
            dt.Columns.Add(new DataColumn("Platform", typeof(string)));
            dt.Columns.Add(new DataColumn("ImageUrl", typeof(string)));
            dt.Columns.Add(new DataColumn("GameId", typeof(int)));

            DataRow dr = dt.NewRow();
            dr["Title"] = "Sample Title 1";
            dr["Platform"] = "Sample Platform 1";
            dr["ImageUrl"] = "https://seeklogo.com/images/S/spider-man-logo-4EA649A533-seeklogo.com.png";
            dr["GameId"] = "100";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Title"] = "Sample Title 2";
            dr["Platform"] = "Sample Platform 1";
            dr["ImageUrl"] = "https://seeklogo.com/images/S/spider-man-logo-4EA649A533-seeklogo.com.png";
            dr["GameId"] = "101";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Title"] = "Sample Title 3";
            dr["Platform"] = "Sample Platform 1";
            dr["ImageUrl"] = "https://seeklogo.com/images/S/spider-man-logo-4EA649A533-seeklogo.com.png";
            dr["GameId"] = "102";
            dt.Rows.Add(dr);

            report.Tables.Add(dt);

            return report;
        }

        //Get the Top Games from database but define the connection string in this method
        public static DataSet GetTopGamesUsingDBWithOutConfig(string gameType)
        {
            string connetionString = null;
            
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dataReader;
            DataTable dt = new DataTable();
            DataSet report = new DataSet();
            
            cnn = new SqlConnection(GetConnectionString());

            string sql = null;
            sql = $"Select * from TopPlayed Where Platform = '{gameType}'";
            
            //Open the connection
            cnn.Open();
            command = new SqlCommand(sql, cnn);                
            dataReader = command.ExecuteReader();
            dt.Load(dataReader);
            report.Tables.Add(dt);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return report;
        }
        
        public static DataSet GetGameAwardsWithOutDB()
        {
            
            DataSet report = new DataSet();

            report.DataSetName = "GamesOn";
            DataTable dt = new DataTable("GameAwards");
            dt.Clear();
            dt.Columns.Add(new DataColumn("Year", typeof(int)));
            dt.Columns.Add(new DataColumn("Game", typeof(string)));
            dt.Columns.Add(new DataColumn("Developer", typeof(string)));
            dt.Columns.Add(new DataColumn("Publisher", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["Year"] = 1990;
            dr["Game"] = "Sample Game 1";
            dr["Developer"] = "Sample Developer 1";
            dr["Publisher"] = "Sample Publisher 1";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Year"] = 1991;
            dr["Game"] = "Sample Game 2";
            dr["Developer"] = "Sample Developer 2";
            dr["Publisher"] = "Sample Publisher 2";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Year"] = 1992;
            dr["Game"] = "Sample Game 3";
            dr["Developer"] = "Sample Developer 3";
            dr["Publisher"] = "Sample Publisher 3";
            dt.Rows.Add(dr);

            report.Tables.Add(dt);

            return report;
        }
        
        public static DataSet GetGameAwardsUsingDBWithOutConfig()
        {
            string connetionString = null;
            
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dataReader;
            DataTable dt = new DataTable();
            DataSet report = new DataSet();
            
            cnn = new SqlConnection(GetConnectionString());

            string sql = null;
            sql = "Select * from GameAwards";
            
            //Open the connection
            cnn.Open();
            command = new SqlCommand(sql, cnn);                
            dataReader = command.ExecuteReader();
            dt.Load(dataReader);
            report.Tables.Add(dt);
            dataReader.Close();
            command.Dispose();
            cnn.Close();

            return report;
        }
        
        public static string GetConnectionString()
        {
            // Replace YourSqlServerInstance with the actual name or IP address of your SQL Server instance
            string server = "localhost";
            string database = "master";
            string username = "sa";
            string password = "<YourStrong@Passw0rd>";

            return $"Data Source={server};Initial Catalog={database};User Id={username};Password={password};";
        }
}
