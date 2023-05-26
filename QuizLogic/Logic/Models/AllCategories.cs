using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trivia4NET;

namespace QuizLogic.Logic.Models
{
    internal class AllCategories
    {
        internal Dictionary<int, string> Get()
        {
            TranslatorDeepl deepl = new TranslatorDeepl();

            Dictionary<int, string> categories = new Dictionary<int, string>();
            var service = new TriviaService();
            var engCategoriesResponse = service.GetCategoriesAsync().GetAwaiter().GetResult().Categories;
            foreach (var category in engCategoriesResponse) categories.Add(category.Id - 8, deepl.Translate(category.Name));

            return categories;
        }
    }
}
