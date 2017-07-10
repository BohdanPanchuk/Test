using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Estafeta_TestTask.Models
{
    public class User
    {
        public static string connectionString = AppDomain.CurrentDomain.BaseDirectory + @"App_Data\TestTaskDatabase.mdf";

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember on this computer")]
        public bool RememberMe { get; set; }

        public bool IsValid(string userName, string password)
        {
            using (SqlConnection mySqlConnection = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " + connectionString + ";Integrated Security=True; Connect Timeout = 30"))
            {
                bool isValid;
                string sqlRequest = @"SELECT [UserName] FROM [dbo].[System_Users] " +
                       @"WHERE [UserName] = " + "'" + userName + "'" + " AND [Password] = " + "'" + password + "'";

                SqlCommand command = new SqlCommand(sqlRequest, mySqlConnection);

                mySqlConnection.Open();

                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }

                reader.Dispose();
                command.Dispose();

                return isValid;
            }
        }
    }
}