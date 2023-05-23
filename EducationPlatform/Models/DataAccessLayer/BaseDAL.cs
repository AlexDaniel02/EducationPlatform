using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Models.DataAccessLayer
{
    public class BaseDAL<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        protected readonly EducationPlatformDbContext _dbContext;
        public BaseDAL(EducationPlatformDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public T? GetByID(int id)
        {
            return _dbSet.Find(id);      
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();

        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _dbContext.SaveChanges();

        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
