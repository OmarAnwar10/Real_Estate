﻿using application.DataAccess;
using Application.DataAccessContracts;
using Microsoft.EntityFrameworkCore;

namespace API_Project.DataAccess.Repositories
{
    internal class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<TEntity> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _db = context;
            _dbSet = _db.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable(); // تأكد من أنها IQueryable
        }

        public virtual TEntity? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            _dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // سجل الخطأ
                throw new Exception("An error occurred while saving changes to the database.", ex);
            }
            catch (InvalidOperationException ex)
            {
                throw new Exception("An invalid operation was attempted.", ex);
            }
        }




        //public virtual void Update(TEntity entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException(nameof(entity));

        //    // تحقق من أن الكيان موجود في قاعدة البيانات
        //    var existingEntity = _dbSet.Find(GetEntityId(entity));
        //    if (existingEntity == null)
        //        throw new KeyNotFoundException("Entity not found in the database.");

        //    try
        //    {
        //        // تأكد من أن الكيان موجود وتم تعقبه
        //        _db.Entry(existingEntity).CurrentValues.SetValues(entity);
        //        _db.Entry(existingEntity).State = EntityState.Modified;
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        // سجل الخطأ إذا كان هناك تعارض في التحديث
        //        throw new Exception("A concurrency error occurred while updating the entity.", ex);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        // سجل الأخطاء الأخرى المتعلقة بالتحديث
        //        throw new Exception("An error occurred while updating the entity.", ex);
        //    }
        //}

        //// توضيح كيفية الحصول على Id للكيان (يمكن أن تحتاج إلى تعديله حسب تصميم الكيان الخاص بك)
        //private int GetEntityId(TEntity entity)
        //{
        //    // افترض أن الكيان يحتوي على خاصية Id. قم بتعديل هذا بناءً على تصميم الكيان الخاص بك.
        //    var idProperty = typeof(TEntity).GetProperty("Id");
        //    if (idProperty == null)
        //        throw new InvalidOperationException("Entity does not have an Id property.");

        //    return (int)idProperty.GetValue(entity);
        //}

    }
}
