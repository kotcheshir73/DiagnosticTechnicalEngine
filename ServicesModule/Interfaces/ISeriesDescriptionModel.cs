using System.Collections.Generic;

namespace ServicesModule.Interfaces
{
	public interface ISeriesDescriptionModel<T, U>
	{
		IEnumerable<T> GetElements(int parentId);

		T GetElement(int id);

		void InsertElement(U model);

		void UpdateElement(U model);

		void DeleteElement(int id);

		void DeleteElements(int seriesId);
	}
}
