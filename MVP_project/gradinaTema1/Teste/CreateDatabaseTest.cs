using gradinaTema1.Model.Repository;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gradinaTema1.Teste
{
    public class CreateDatabaseTest
    {
        [Test]
        public void CreateTablePlant_Success()
        {
            // Arrange
            CreateDatabase createDatabase = new CreateDatabase("GradinaB");

            // Act
            createDatabase.CreateTablePlant();

            // Assert
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=GradinaB;"))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Plant'", conn))
                {
                    int tableCount = (int)command.ExecuteScalar();
                    ClassicAssert.AreEqual(1, tableCount, "Table 'Plant' was not created.");
                }
            }
        }

        [Test]
        public void CreateTableUser_Success()
        {
            // Arrange
            CreateDatabase createDatabase = new CreateDatabase("GradinaB");

            // Act
            createDatabase.CreateTableUser();

            // Assert
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=GradinaB;"))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Users'", conn))
                {
                    int tableCount = (int)command.ExecuteScalar();
                    ClassicAssert.AreEqual(1, tableCount, "Table 'Users' was not created.");
                }
            }
        }

        [Test]
        public void AddInitialData_Success()
        {
            // Arrange
            CreateDatabase createDatabase = new CreateDatabase("GradinaB");

            // Act
            createDatabase.AddInitialData();

            // Assert
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated Security=True;Database=GradinaB;"))
            {
                conn.Open();
                // Check if there is data in the Plant table
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Plant", conn))
                {
                    int rowCount = (int)command.ExecuteScalar();
                    ClassicAssert.Greater(rowCount, 0, "No data was inserted into the Plant table.");
                }

                // Check if there is data in the Users table
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Users", conn))
                {
                    int rowCount = (int)command.ExecuteScalar();
                    ClassicAssert.Greater(rowCount, 0, "No data was inserted into the Users table.");
                }
            }
        }
    }
}
