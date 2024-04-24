using Library.Data.Contracts;
using Library.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class UserDataAccess : IUserDataAccess
    {
   

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(string key)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            User user = null;
            var conStr = CommonUtility.CommonUtils.GetConnectionStr();
            using(SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                var sqlCommand = new SqlCommand("Select * from users where email=@email",con);
                sqlCommand.Parameters.AddWithValue("@email", email);

                var data = new SqlDataAdapter(sqlCommand);
                var dataTable = new DataTable();
                data.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    user = FromDataTable(dataTable.Rows[0]);
                }
                else
                    CommonUtility.Log.Warn("No user found for the email " + email);

            }

            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var conStr = CommonUtility.CommonUtils.GetConnectionStr();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                var sqlCommand = new SqlCommand("Select * from users where deleteddate is null",con);

                var data = new SqlDataAdapter(sqlCommand);
                var dataTable = new DataTable();
                data.Fill(dataTable);

                users = FromDataTable(dataTable);

            }

            return users;
        }

        public User InsertUser(Hashtable user)
        {
            throw new NotImplementedException();
        }

        private User FromDataTable(DataRow row)
        {
            User user = new User();

            user.Id = (int)row["Id"];
            user.Name = (string)row["Name"];
            user.Email = (string)row["Email"];
            user.Password = (string)row["Password"];
            user.Mobile =  !DBNull.Value.Equals(row["Mobile"]) ? (string)row["Mobile"] : "";
            user.Phone =   !DBNull.Value.Equals(row["Phone"]) ?  (string)row["Phone"] : "";    

            return user;
        }

        private List<User> FromDataTable(DataTable table)
        {
            List<User> users = new List<User>();

            foreach(DataRow row in table.Rows)
            {
                users.Add(FromDataTable(row));
            }

            return users;
        }
    }
}
