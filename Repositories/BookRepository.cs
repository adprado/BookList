using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;


namespace secondAPI.Repositories
{

    public class BookRepository : IBookRepository
    {
        private readonly string _connectionString;

        public BookRepository(IConfiguration configuration)
        {
            _connectionString =  configuration.GetConnectionString("Default");
        }

        public async Task<Book> Post(Book book)
        {
            var sqlQuery = "insert into books values(@id, @title, @author, @genre, @yearfirstpub)";

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                await connection.ExecuteAsync(sqlQuery, new{
                    book.Id,
                    book.Title,
                    book.Author,
                    book.Genre,
                    book.YearFirstPub
                });
                
                return book;
            }
        }

        public async Task<IEnumerable<Book>> Get()
        {
            var sqlQuery = "select * from books";
            
            using (SqlConnection connection = new SqlConnection(_connectionString))  {
                
                return await connection.QueryAsync<Book>(sqlQuery);
            }
            
        }

        public async Task<Book> Get(int number)
        {
            var sqlQuery = "select * from books where id=@Id";

            using (SqlConnection connection = new SqlConnection(_connectionString)){

                return await connection.QueryFirstOrDefaultAsync<Book>(sqlQuery, new Book{Id = number });
            }
        }

        public async Task Change(int number, Book book)
        {
            var sqlQuery = "update books set title=@title, author=@author, genre=@genre, yearfirstpub=@yearfirstpub where id=@number";

            using (SqlConnection connection = new SqlConnection(_connectionString)){
                await connection.ExecuteAsync(sqlQuery, new{
                    number,
                    book.Title,
                    book.Author,
                    book.Genre,
                    book.YearFirstPub
                });
            }
        }

        public async Task Delete(int number)
        {
            var sqlQuery = "delete from books where id=@Id";

            using (SqlConnection connection = new SqlConnection(_connectionString)) {
                await connection.ExecuteAsync(sqlQuery, new Book{Id = number});
            }
        }

        

        
    }
}