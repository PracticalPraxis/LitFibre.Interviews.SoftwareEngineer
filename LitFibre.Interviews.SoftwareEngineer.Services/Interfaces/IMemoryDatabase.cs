using LitFibre.Interviews.SoftwareEngineer.Models.Data;
using LitFibre.Interviews.SoftwareEngineer.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LitFibre.Interviews.SoftwareEngineer.Services.Interfaces
{
    public interface IMemoryDatabase<T>
        where T : DatabaseObject
    {
        /// <summary>
        /// Retrieve an object of type T from the database
        /// </summary>
        /// <param name="id">ID of the object</param>
        /// <returns>Object of type T or null</returns>
        T Read(string id)
        {
            return _context.FirstOrDefaultAsync(order => order.Id == id);
        };

        /// <summary>
        /// Insert or update an object of type T in the database
        /// </summary>
        /// <param name="item">Object to insert or update. If the object's ID matches and existing ID in the database, it will be updated</param>
        void Push(T item)
        {

        };

        /// <summary>
        /// Deletes an object from the database
        /// </summary>
        /// <param name="id">ID of the object to delete</param>
        /// 
        void Delete(string id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }
        };

        /// <summary>
        /// Deletes an object from the database
        /// </summary>
        /// <param name="item">The object to delete</param>
        void Delete(T item);

        /// <summary>
        /// Queries the entire database using a predicate
        /// </summary>
        /// <param name="predicate">Predicate that will be run against all objects in the database</param>
        /// <returns>The results of the query</returns>
        IEnumerable<T> Query(Predicate<T> predicate);
    }
}
