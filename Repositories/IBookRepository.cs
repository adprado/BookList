using System;
using System.Collections.Generic; 
using System.Threading.Tasks;
using System.Data.SqlClient;
using secondAPI;

namespace secondAPI.Repositories
{

    public interface IBookRepository
    {
        Task<Book> Post(Book book);
        
        Task<IEnumerable<Book>> Get();

        Task<Book> Get(int number);

        Task Change(int number, Book book);

        Task Delete(int number);
    }
}