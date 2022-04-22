using System;
using Week8Rubrica.Core.Entities;

namespace Week8Rubrica.Core.Repositories
{
	public interface IRepositoryContatti:IRepository<Contatto>
	{
		List<Contatto> GetAll();
		Contatto GetById(int id);
		bool Delete(Contatto contatto);


	}
}

