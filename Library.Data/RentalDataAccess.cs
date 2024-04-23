using Library.Data.Contracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data
{
    public class RentalDataAccess : IRentalDataAccess
    {
        public List<RentalRecord> GetRecordsForUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool HasPendingReturns(int id)
        {
            var hasBooks = false;
            var conStr = CommonUtility.CommonUtils.GetConnectionStr();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                var sqlCommand = new SqlCommand("Select count(*) from RentalRecords where UserId=@UserId and ReturnDate is null", con);
                sqlCommand.Parameters.AddWithValue("@UserId", id);

                var totalPendingBooks = (int)sqlCommand.ExecuteScalar();
                hasBooks = totalPendingBooks > 0;
            }

            return hasBooks;
        }

        public RentalRecord NewRental(int bookId, int id)
        {
            var conStr = CommonUtility.CommonUtils.GetConnectionStr();
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                var sqlCommand = new SqlCommand("insert into rentalrecords(userid,bookid,duedate,createddate) values(@userid,@bookid,@duedate,getDate())", con);
                sqlCommand.Parameters.AddWithValue("@userid", id);
                sqlCommand.Parameters.AddWithValue("@bookid", bookId);
                sqlCommand.Parameters.AddWithValue("@duedate", DateTime.Now.AddDays(7));

                sqlCommand.ExecuteNonQuery();

                return new RentalRecord();
                
            }
        }
    }
}
