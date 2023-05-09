using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomMealGenerator
{
    internal class Meal
    {
        private string name;
        private string area;
        //private string[] ingredience;

        public string Name { get; set; }
        public string Area { get; set; }
        public string Ingredients { get; set; }
        public string Recipe { get; set; }

        public Meal(string name, string area, string ingredients, string recipe)
        {
            this.Name = name;
            this.Area = area;
            this.Ingredients = ingredients;
            this.Recipe = recipe;
        }

    }
}
