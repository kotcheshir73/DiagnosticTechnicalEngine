﻿namespace DatabaseModule
{
	/// <summary>
	/// Перечисление для аномалий. Какой вариант хранения числовых значений для посторения графика используется
	/// </summary>
	public enum TypeMemoryValue
	{
		/// <summary>
		/// Храняться значения числового временного ряда
		/// </summary>
		ПоЗначению,
		/// <summary>
		/// Храняться значения функции принадлежности точки в нечетокй метки для НВР
		/// </summary>
		ПоФункции
	}
}
