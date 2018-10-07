using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DrinkThing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize a string for user choice, set as an empty string
            string choice = "";

            List<Drink> drinks = new List<Drink>();

            // While the user's choice is not "Q" (or "q," which will be capitalized on input),
            // continue this loop
            while (choice != "Q")
            {

                // Get a user's choice
                choice = PromptUserChoice();

                // Check user's choice against switch cases
                switch (choice)
                {
                    // If "1" is entered,
                    case "1":
                        // search drink by name,
                        string drinkToFind = SearchByName();
                        // provide a list of drinks that match that name,
                        drinks = GetDrinksByDrinkName(drinkToFind);
                        // and return the ingredients and instructions for a selected drink
                        if(drinks == null || drinks.Count == 0) {
                            break;
                        }
                        ReturnIngredientsAndInstructions(drinks);
                        break;
                    // If "2" is entered,
                    case "2":
                        string ingredientToSearchBy = SearchByIngredient();
                        drinks = DrinksByIngredient(ingredientToSearchBy);
                        if(drinks == null || drinks.Count == 0) {
                            break;
                        }
                        ReturnIngredientsAndInstructions(drinks);
                        break;
                    case "3":
                        drinks = GetRandomDrink();
                        ReturnIngredientsAndInstructions(drinks);
                        break;
                    default:
                        Console.Clear();
                        break;
                }

                // Prompt for another selection, or allow user to exit program
                Console.WriteLine("\nWould you like to search again, or (Q)uit?");

                // Get an updated choice
                choice = Console.ReadLine();
                // If a letter is entered, ensure it is capitalized
                choice = CapitalizeLetters(choice);

                // Wait 1 second (Thread.Sleep() takes millisecond increments)
                Thread.Sleep(1000);

                // Clear the console
                Console.Clear();
            }

            // Say farewell to your user
            Console.WriteLine("Goodbye!");

        }

        /// <summary>
        /// Checks an entered string, returns it uppercased if it is composed of ONLY letters
        /// </summary>
        /// <returns>A string, capitalized if all its characters are alphabetical</returns>
        /// <param name="choice">The user's choice</param>
        static string CapitalizeLetters(string choice)
        {

            if (Regex.IsMatch(choice, @"^[a-zA-Z]+$"))
            {
                choice = choice.ToUpper();
            }

            return choice;
        }

        /// <summary>
        /// Prompts a user for its choice
        /// </summary>
        /// <returns>The user's choice</returns>
        static string PromptUserChoice()
        {

            Console.WriteLine("Welcome human. How would you like to search for your adult beverage*?");
            Console.WriteLine("*(NOTE: adult beverage means a beverage intended for adult consumption,\n not a beverage that is itself of age.)");

            Console.WriteLine("1. Search by drink name");
            Console.WriteLine("2. Search by ingredient");
            Console.WriteLine("3. YOLO -- Give me a random drink");
            Console.WriteLine("Q. Make it stop");

            string choice = Console.ReadLine();

            // Capitalize letters (if all characters in entered string are alphabetical)
            choice = CapitalizeLetters(choice);

            // Return the provided choice
            return choice;
        }

        /// <summary>
        /// Gets name of a drink to search for
        /// </summary>
        /// <returns>The given name.</returns>
        static string SearchByName()
        {
            // Get user input to search for
            Console.Write("What drink would you like to search for?: ");
            string drinkToFind = Console.ReadLine();
            return drinkToFind;
        }

        static string SearchByIngredient()
        {
            Console.Write("What ingredient would you like to search by?: ");
            string ingredientToFind = Console.ReadLine();
            return ingredientToFind;
        }

        /// <summary>
        /// Gets a list of drinks by a given ingredient
        /// </summary>
        /// <returns>A list of drinks</returns>
        /// <param name="ingredient">The ingredient to search by</param>
        static List<Drink> DrinksByIngredient(string ingredient)
        {
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={ingredient}";

            List<Drink> drinks = GetDrinksFromAPI(url);

            // Uncomment this to get drink details for every single drink returned
            // (will make program appear slow or unresponsive if many drinks are found)
            //for (int i = 0; i < drinks.Count; i++)
            //{
            //    drinks[i] = GetDrinkDetails(drinks[i]);
            //}

            return drinks;
        }

        /// <summary>
        /// Gets drinks from provided URL
        /// </summary>
        /// <returns>The drinks from API</returns>
        /// <param name="url">URL for API</param>
        static List<Drink> GetDrinksFromAPI(string url)
        {
            // Get the response from the URL as a string
            string json = new WebClient().DownloadString(url);

            List<Drink> drinks = new List<Drink>();

            // If there is no match for the search,
            if (string.IsNullOrEmpty(json))
            {
                // notify user
                NothingFound();
                return drinks;
            }

            // Get the amount of the string to chop off to keep only the array of objects that is returned
            int lengthToChop = json.Length - 11;

            // Replace the current json body with the body minus the string "drinks," using lengthToChop previously declared
            json = (json.Substring(10, lengthToChop));

            // Get a list of drinks (as returned from the API), deserialized as a list of Drink objects
            drinks = JsonConvert.DeserializeObject<List<Drink>>(json);

            if(drinks == null) {
                // notify user
                NothingFound();
                return drinks;
            }

            if (drinks.Count > 1)
            {
                ListDrinks(drinks);
            }

            return drinks;
        }

        /// <summary>
        /// List drinks
        /// </summary>
        /// <param name="drinks">List of drinks to list</param>
        static void ListDrinks(List<Drink> drinks)
        {
            // Return drinks list by...
            Console.WriteLine("Your drinks!!!:");
            // ... looping through each drink result 
            for (int i = 0; i < drinks.Count; i++)
            {
                Console.WriteLine($"{i + 1}.) {drinks[i].strDrink}");
            }

            return;

        }

        /// <summary>
        /// Gets a selection of drinks from API
        /// </summary>
        /// <returns>A list of drinks from API response</returns>
        /// <param name="drinkToFind">The drink name to search for</param>
        static List<Drink> GetDrinksByDrinkName(string drinkToFind)
        {
            // Append user-chosen drink to URL string
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/search.php?s={drinkToFind}";

            // Return the list that was found
            return GetDrinksFromAPI(url);
        }

        /// <summary>
        /// Gets a random drink
        /// </summary>
        /// <returns>A random drink</returns>
        static List<Drink> GetRandomDrink()
        {
            string url = "https://www.thecocktaildb.com/api/json/v1/1/random.php";

            return GetDrinksFromAPI(url);
        }

        /// <summary>
        /// Returns ingredients and instructions for a user's drink selection
        /// </summary>
        /// <param name="drinks">A list of drinks to select from</param>
        static void ReturnIngredientsAndInstructions(List<Drink> drinks)
        {

            if (drinks.Count > 1)
            {
                PromptForDrinkFromList(drinks);
            }
            else
            {
                // Return ingredients
                Console.WriteLine($"\nFor a {drinks[0].strDrink}, you'll need...");
                // Loop through each ingredient for the drink, and write each one
                foreach (string ingredient in drinks[0].Ingredients)
                {
                    Console.WriteLine(ingredient);
                }

                // Return recipe for drink
                Console.WriteLine("\nDo this:");
                // List instructions for the given drink
                Console.WriteLine(drinks[0].strInstructions);
            }

            return;
        }

        /// <summary>
        /// Prompts a user for a drink from a list of drinks
        /// </summary>
        /// <param name="drinks">A list of drinks</param>
        static void PromptForDrinkFromList(List<Drink> drinks)
        {
            // Prompt for a choice from the list
            Console.WriteLine("\nYour choice for a recipe?");

            // Get the choice (-1 to compensate for 0-based index --
            // see where the index is i+1 in the loop above)
            int index = int.Parse(Console.ReadLine()) - 1;

            // If a drink has no listed ingredients, or a drink has no instructions,
            if(drinks[index].Ingredients.Count == 0 || drinks[index].Ingredients == null ||
               drinks[index].strInstructions == null || drinks[index].strInstructions == "") {
                // get those details from the API
                drinks[index] = GetDrinkDetails(drinks[index]);
            }

            // Return ingredients
            Console.WriteLine($"\nFor a {drinks[index].strDrink}, you'll need...");
            // Loop through each ingredient for the drink, and write each one
            foreach (string ingredient in drinks[index].Ingredients)
            {
                Console.WriteLine(ingredient);
            }

            // Return recipe for drink
            Console.WriteLine("\nDo this:");
            // List instructions for the given drink
            Console.WriteLine(drinks[index].strInstructions);

            return;
        }

        /// <summary>
        /// Gets details for a given drink
        /// </summary>
        /// <returns>The drink, with details filled in</returns>
        /// <param name="drink">A drink to search for</param>
        static Drink GetDrinkDetails(Drink drink)
        {
            // Append user-chosen drink ID to URL
            string url = $"https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i={drink.idDrink}";

            // Get the response from the URL as a string
            string json = new WebClient().DownloadString(url);

            // Get the amount of the string to chop off to keep only the array of objects that is returned
            int lengthToChop = json.Length - 11;

            // Replace the current json body with the body minus the string "drinks," using lengthToChop previously declared
            json = (json.Substring(10, lengthToChop));

            // Get a list of drinks (as returned from the API), deserialized as a list of Drink objects
            List<Drink> drinks = JsonConvert.DeserializeObject<List<Drink>>(json);

            return drinks[0];

        }

        /// <summary>
        /// If no matches for a search is found, return on down to the program backbone
        /// </summary>
        static void NothingFound()
        {
            Console.WriteLine("Nothing found for that search. Press any key to try again.");
            string answer = Console.ReadLine();

            answer = CapitalizeLetters(answer);

            Console.Clear();
            return;
        }

    }
}
