using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppBlazor3.Services
{
	public interface IGenericService<T> where T : class
	{
		Task<int> Insert(T t);
		Task<int> Update(T t);
		Task<int> Delete(T t);
		Task<T> GetById(int id);
		Task<List<T>> GetAll();

	}
}
