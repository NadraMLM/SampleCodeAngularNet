using CodeSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using CodeSample.Data;

namespace CodeSample.Repositories
{
	public class EntityRepository<T> : IEntityRepository<T>
		where T : class, IEntity, new()
	{
		protected readonly ApplicationDbContext _context;

		#region Properties
		public EntityRepository(ApplicationDbContext context)
		{
			_context = context;
		}
		#endregion
		public virtual IEnumerable<T> GetAll()
		{
			return _context.Set<T>().AsEnumerable();
		}

		public virtual int Count()
		{
			return _context.Set<T>().Count();
		}
		public virtual IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}
			return query.AsEnumerable();
		}

		public async Task<T> GetSingle(String id)
		{
			return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
		}

		public virtual async Task<T> GetSingle(Expression<Func<T, bool>> predicate)
		{
			return await _context.Set<T>().FirstOrDefaultAsync(predicate);
		}

		public virtual async Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> query = _context.Set<T>();
			foreach (var includeProperty in includeProperties)
			{
				query = query.Include(includeProperty);
			}

			return await query.Where(predicate).FirstOrDefaultAsync();
		}

		public virtual IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
		{
			return _context.Set<T>().Where(predicate);
		}

		public async virtual Task Add(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			//EntityEntry dbEntityEntry = _context.Entry<T>(entity);
			await _context.Set<T>().AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public virtual async Task Update(T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}
			//EntityEntry dbEntityEntry = _context.Entry<T>(entity);
			//dbEntityEntry.State = EntityState.Modified;
			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}
		public virtual async Task Update(T oldEntity, T entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			//_context.Entry<T>(oldEntity).CurrentValues.SetValues(entity);
			var contextEntry = _context.Entry<T>(oldEntity);
			contextEntry.State = EntityState.Detached;
			_context.Attach(entity);

			_context.Set<T>().Update(entity);
			await _context.SaveChangesAsync();
		}
		public virtual async Task Delete(T entity)
		{
			//EntityEntry dbEntityEntry = _context.Entry<T>(entity);
			//dbEntityEntry.State = EntityState.Deleted;
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_context.Set<T>().Remove(entity);
			await _context.SaveChangesAsync();
		}

		public virtual async Task DeleteWhere(Expression<Func<T, bool>> predicate)
		{
			IEnumerable<T> entities = _context.Set<T>().Where(predicate);

			foreach (var entity in entities)
			{
				//_context.Entry<T>(entity).State = EntityState.Deleted;
				_context.Set<T>().Remove(entity);
			}
			await _context.SaveChangesAsync();
		}

	}
}
