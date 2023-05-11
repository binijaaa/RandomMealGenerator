using Newtonsoft.Json;
using System.Diagnostics.Metrics;
using System.Net.Http;
using System.Threading.Tasks;


namespace RandomMealGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Meal test = new Meal("Pizza","Italy", "something, something, ...", "Recepe description");
            //Console.WriteLine($"Testing: {test.Name}" );

            Console.WriteLine("Choose a country: ");
            string country = Console.ReadLine();

            //string testing = RandomizeMealByCountry(country);

            //Randomize(country);
            //Console.WriteLine(country);




            HttpClient client = new HttpClient();
            string response = client.GetStringAsync($"https://api.edamam.com/search?app_id=38c4fcc6&app_key=024de75c4492cec0c489343537b5e7ca&from=0&to=10&q={country}").Result; //0 to 10 - the amount of recipes for randomizing
            
            Rootobject ApiResultObject = JsonConvert.DeserializeObject<Rootobject>(response);
            if(ApiResultObject.hits.Length > 0 )
            {
                var recipe = ApiResultObject.hits[GetRandomNumber(ApiResultObject.count)].recipe;

                Console.WriteLine($"Recipe label: {recipe.label}"); //can put whatever info from meal.cs (gotten from API)
                Console.WriteLine($"Country: {country}");
                Console.WriteLine($"Recipe ingredients:");
                foreach(var ingredient in recipe.ingredientLines)//using foreach since the ingredients are in a list
                {
                    Console.WriteLine($"  {ingredient}");
                }
                Console.WriteLine($"Total calories: {recipe.calories}");
                Console.WriteLine($"Source: {recipe.source} | {recipe.url}");
            }
            else //gives if recipe count is 0
            {
                Console.WriteLine("sorry, no recipes found!");
            }
        }

        static int GetRandomNumber(int maxRecipeCount) //gives a random recipe from 0-10 found hits (specified in API URL)
        {
            int maxValue = 10;
            if(maxRecipeCount < maxValue) //if recipe count is lower than chosen 10
            {
                maxValue = maxRecipeCount+1; // +1 because the random.next function gives max excluding nr 10
            }

            Random random = new Random();
            int randomNumber = random.Next(0, maxValue); // generates a random integer between 0 and 9 (inclusive)
            return randomNumber;
        }
            



        //static void Randomize(string country)
        //{
            
           // Console.WriteLine("I am here");


        //}

        //public string RandomizeMealByCountry(string country)
        //{
        //    return "yes";
        //}

       
        //int allMeals = TotalMeals();
       // int randomMealNr = RandomizeMeal(allMeals);

        //static int RandomizeMeal(int allMeals)
        //{
        //    Random random = new Random();
        //    return random.Next(1, allMeals + 1);
        //}
        
    }
}

