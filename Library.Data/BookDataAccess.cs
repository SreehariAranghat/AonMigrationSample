using Library.Data.Contracts;
using Library.Entities;
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
    public class BookDataAccess : IBookAccessService
    {
        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exist(string key)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetBooks()
        {
           
                List<Book> books = new List<Book>();
                var conStr = CommonUtility.CommonUtils.GetConnectionStr();
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    var sqlCommand = new SqlCommand("Select * from books where deleteddate is null", con);

                    var data = new SqlDataAdapter(sqlCommand);
                    var dataTable = new DataTable();
                    data.Fill(dataTable);

                books = FromDataTable(dataTable);

                }

                return books;
            
        }

        public Book InsertBook(Hashtable book)
        {
            throw new NotImplementedException();
        }

        private Book FromDataTable(DataRow row)
        {
            Book book = new Book();

            book.Id = (int)row["Id"];
            book.Name = (string)row["Name"];
            book.Title = (string)row["Title"];
            book.Author = (string)row["Author"];
            
            return book;
        }


        private List<Book> FromDataTable(DataTable table)
        {
            List<Book> books = new List<Book>();

            foreach (DataRow row in table.Rows)
            {
                books.Add(FromDataTable(row));
            }

            return books;
        }
    }
}
