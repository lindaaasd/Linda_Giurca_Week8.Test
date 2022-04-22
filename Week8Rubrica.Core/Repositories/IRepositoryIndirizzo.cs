using System;
using Week8Rubrica.Core.Entities;

namespace Week8Rubrica.Core.Repositories
{
	public interface IRepositoryIndirizzo:IRepository<Indirizzo>
	{
		List<Indirizzo> GetByContactID(int id);
	}
}

