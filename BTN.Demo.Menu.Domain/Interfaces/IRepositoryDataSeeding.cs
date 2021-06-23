using BTN.Demo.Menu.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BTN.Demo.Menu.Domain.Interfaces
{
    /// <summary>
    /// Interface for seeding data into a given repository
    /// </summary>
    public interface IRepositoryDataSeeding<T> where T : BaseEntity
    {
        /// <summary>
        /// Seeds data into a given repository
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task Seed(IEnumerable<T> data);

        /// <summary>
        /// Resets current data
        /// </summary>
        /// <returns></returns>
        Task Reset();
    }
}
