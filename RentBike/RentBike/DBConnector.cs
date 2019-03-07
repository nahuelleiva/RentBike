using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;

namespace RentBike
{
    public class DBConnector
    {
        private const string DBName = "database.sqlite";
        private const string SQLScript = @"..\..\..\Scripts\database.sql";
        private static bool IsDbRecentlyCreated = false;

        /// <summary>
        /// Creates the database for future usages.
        /// </summary>
        public void CreateDB()
        {
            // Creates the db just once
            if (!File.Exists(Path.GetFullPath(DBName)))
            {
                SQLiteConnection.CreateFile(DBName);
                IsDbRecentlyCreated = true;
            }

            // Using the database instances that we've created
            using (var ctx = GetInstance())
            {
                if (IsDbRecentlyCreated)
                {
                    var path = Path.GetFullPath(SQLScript);
                    using (var reader = new StreamReader(Path.GetFullPath(SQLScript)))
                    {
                        // We take the file that has the SQL instruction and we execute it
                        var query = "";
                        var line = "";
                        while ((line = reader.ReadLine()) != null)
                        {
                            query += line;
                        }

                        using (var command = new SQLiteCommand(query, ctx))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        
        /// <summary>
        /// Insert a new object to database
        /// </summary>
        /// <param name="pNewRent">Rent object to be added to DB</param>
        public void InsertNewRent(RentBikeModel pNewRent)
        {
            var connection = GetInstance();
            var sqlInsert = string.Format("INSERT INTO Rents (Bikes, Total, IsFamily) VALUES ({0}, {1}, {2})", 
                pNewRent.getBikes(), pNewRent.getTotal().ToString().Replace(",", "."), pNewRent.getIsFamily());
            SQLiteCommand command = new SQLiteCommand(sqlInsert, connection);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Creates and and returns a connection instance to be able to manipulate afterwards.
        /// </summary>
        /// <returns>SQLConnection object</returns>
        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection(
                string.Format("Data Source={0};Version=3;", DBName)
            );

            db.Open();

            return db;
        }

        /// <summary>
        /// Returns the total of records stored
        /// </summary>
        /// <returns>int</returns>
        public long GetTotalRecords() {
            var connection = GetInstance();
            var sqlSelect = "SELECT COUNT(*) FROM Rents";
            SQLiteCommand command = new SQLiteCommand(sqlSelect, connection);
            long total = (long)command.ExecuteScalar();
            return total;
        }
    }
}
