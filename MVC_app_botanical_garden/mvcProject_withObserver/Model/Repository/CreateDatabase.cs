using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace gradinaTema1.Model.Repository
{
    public class CreateDatabase
    {
        private static string DBURL = "Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;";


        private string dbName;
        private static CreateDatabase singleInstance;

        public CreateDatabase() { }

        public CreateDatabase(string dbName)
        {
            this.dbName = dbName;

            try
            {
                singleInstance = this;
                using (SqlConnection connection = new SqlConnection(DBURL))
                {
                    connection.Open();
                    string query = "CREATE DATABASE " + dbName;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Database " + dbName + " created successfully!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error creating new database");
                Console.WriteLine(e.Message);
            }
        }

        public void CreateTablePlant()
        {
            using (SqlConnection conn = new SqlConnection(DBURL))
            {
                try
                {
                    conn.Open();
                    string query = @"CREATE TABLE Plant (
                    plant_id INT IDENTITY(1,1) PRIMARY KEY,
                    plant_name VARCHAR(50),
                    species VARCHAR(100),
                    plant_type VARCHAR(50),
                    carnivorous VARCHAR(3),
                    location VARCHAR(50)
                );";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Table Plant created successfully!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void CreateTableUser()
        {
            using (SqlConnection conn = new SqlConnection(DBURL))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        CREATE TABLE Users (
                            user_id INT IDENTITY(1,1) PRIMARY KEY,
                            person_id INT NOT NULL,
                            username VARCHAR(50),
                            password VARCHAR(50),
                            admin_status VARCHAR(3),
                            FOREIGN KEY (person_id) REFERENCES Users(person_id)
                        )";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                    Console.WriteLine("Table Users created successfully!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void AddInitialData()
        {
            using (SqlConnection conn = new SqlConnection(DBURL))
            {
                try
                {
                    conn.Open();
                    string query = @"INSERT INTO plant (plant_name, species, plant_type, carnivorous, location) VALUES 
                ('lalea', 'tulipa gesneriana', 'magnoliophyta', 'no', 'center'),
                ('trandafir', 'rosa chinensis', 'magnoliophyta', 'no', 'center'),
                ('crin', 'lilium candidum', 'magnoliophyta', 'no', 'center'),
                ('crizantema', 'chrysanthemum', 'magnoliophyta',  'no', 'back area'),
                ('muscata', 'pelargonium graveolens', 'magnoliophyta', 'no', 'left entrance'),
                ('pin', 'pinus pinea', 'gymnospermae', 'no', 'left entrance'),
                ('visin', 'prunus avium', 'angiospermae', 'no',  'left entrance'),
                ('juniper', 'juniperus communis', 'gymnospermae', 'no',  'right entrance');";

                using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }

                    query = @"INSERT INTO users (person_id, username, password, admin_status) VALUES 
                        (1, 'ana_poop', 'pass', 'no'),
                        (2, 'maty00', 'maty', 'no'),
                        (3, 'Lucca', 'lucarus', 'no'),
                        (4, 'Lavyy', 'rusL', 'no'),
                        (5, 'admin', 'admin', 'yes');";
                        
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine("Initial data was added to the database successfully!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
