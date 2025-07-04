using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Handlers
{
	public class Category
	{
		public static List<core.Models.Categories_Model> GetCategories()
		{
			try
			{
				var Categories = Infrastructure.Data.Access.Tables.CategoryAccess.Get();
				var categories = new List<core.Models.Categories_Model>();
				foreach (var category in Categories)
				{
					categories.Add(new core.Models.Categories_Model()
					{
						category_name = category.nom_category,
						id_category = category.ID_categroy
					});
				}
				return categories;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}


		public static core.Models.Categories_Model GetCategorieByID(int ID)
		{
			try
			{
				var Categories = Infrastructure.Data.Access.Tables.CategoryAccess.Get(ID);
				var categories = new core.Models.Categories_Model();

				categories.category_name = Categories.nom_category;
				categories.id_category = Categories.ID_categroy;
				
				return categories;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
