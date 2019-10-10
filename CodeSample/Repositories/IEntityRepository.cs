using CodeSample.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodeSample.Repositories
{
	public interface IEntityRepository<T> where T : class, IEntity, new()
	{
		IEnumerable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
		IEnumerable<T> GetAll();
		int Count();
		Task<T> GetSingle(String id);
		Task<T> GetSingle(Expression<Func<T, bool>> predicate);
		Task<T> GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
		IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
		Task Add(T entity);
		Task Update(T entity);
		Task Update(T oldEntity, T entity);
		Task Delete(T entity);
		Task DeleteWhere(Expression<Func<T, bool>> predicate);
	}
}
