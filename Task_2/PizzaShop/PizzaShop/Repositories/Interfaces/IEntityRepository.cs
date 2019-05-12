using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaShop.Repositories.Interfaces
{
    public interface IEntityRepository<T>
    {
        IEnumerable<T> Elements { get; }

        T GetById(int? id);
        Task<T> GetByIdAsync(int? id);

        bool Exists(int id);

        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        void Add(T element);
        void Update(T element);
        void Remove(T element);

        void SaveChanges();
        Task SaveChangesAsync();

    }
}
