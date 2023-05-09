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
            Meal test = new Meal("Pizza","Italy", "something, something, ...", "Recepe description");
            Console.WriteLine($"Testing: {test.Name}" );

            Console.WriteLine("Choose a country: ");
            string country = Console.ReadLine();

            //string testing = RandomizeMealByCountry(country);

            Randomize(country);
            //Console.WriteLine(country);




            HttpClient client = new HttpClient();
            string response = client.GetStringAsync($"https://api.spoonacular.com/recipes/random?tags={country}&apiKey=7fcf8633f41b49f1ba173b54e7f6504b").Result;
            
            XXXX root = JsonConvert.DeserializeObject<XXXX>(response); //need to make a new class.cs with all the info from API in json
            

            Console.WriteLine();
        }

        static void Randomize(string country)
        {
            
            Console.WriteLine("I am here");


        }

        public string RandomizeMealByCountry(string country)
        {
            return "yes";
        }

       
        //int allMeals = TotalMeals();
       // int randomMealNr = RandomizeMeal(allMeals);

        static int RandomizeMeal(int allMeals)
        {
            Random random = new Random();
            return random.Next(1, allMeals + 1);
        }
        
    }
}

