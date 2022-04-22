using System;
namespace Week8Rubrica.Core.Repositories
{
	public interface IRepository<T>
	{

		bool Add(T item);

	}
}

