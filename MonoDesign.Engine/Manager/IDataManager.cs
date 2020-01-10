using System;
using System.Collections.Generic;
using System.Text;

namespace MonoDesign.Engine.Manager
{
	interface IDataManager<T> {
		IEnumerable<T> GetItems();
		void Save(T item);
		void SaveAll();
		void Create(T item);
		void Remove(T item);
		void Reload();
		void Load();
	}
}
