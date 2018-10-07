using System;
using System.Collections.Generic;

namespace DrinkThing
{
    public class Drink
    {
        // Build the list of ingredients from strIngredient + strMeasure properties returned from the API --
        // if an ingredient is not returned as an empty string, add it to the list, along with its corresponding measurement
        public List<string> Ingredients
        {
            get
            {
                List<string> ingredients = new List<string>();

                if (strIngredient1 != "")
                {
                    string ingred1 = "";

                    if (strMeasure1 != "\n")
                    {
                        ingred1 = strMeasure1 + " " + strIngredient1;
                    }
                    else
                    {
                        ingred1 = strIngredient1;
                    }
                    ingredients.Add(ingred1);
                }
                if (strIngredient2 != "")
                {
                    string ingred2 = "";

                    if (strMeasure2 != "\n")
                    {
                        ingred2 = strMeasure2 + " " + strIngredient2;
                    }
                    else
                    {
                        ingred2 = strIngredient2;
                    }
                    ingredients.Add(ingred2);
                }
                if (strIngredient3 != "")
                {
                    string ingred3 = "";

                    if (strMeasure3 != "\n")
                    {
                        ingred3 = strMeasure3 + " " + strIngredient3;
                    }
                    else
                    {
                        ingred3 = strIngredient3;
                    }
                    ingredients.Add(ingred3);
                }
                if (strIngredient4 != "")
                {
                    string ingred4 = "";

                    if (strMeasure4 != "\n")
                    {
                        ingred4 = strMeasure4 + " " + strIngredient4;
                    }
                    else
                    {
                        ingred4 = strIngredient4;
                    }
                    ingredients.Add(ingred4);
                }
                if (strIngredient5 != "")
                {
                    string ingred5 = "";

                    if (strMeasure5 != "\n")
                    {
                        ingred5 = strMeasure5 + " " + strIngredient5;
                    }
                    else
                    {
                        ingred5 = strIngredient5;
                    }
                    ingredients.Add(ingred5);
                }
                if (strIngredient6 != "")
                {
                    string ingred6 = "";

                    if (strMeasure6 != "\n")
                    {
                        ingred6 = strMeasure6 + " " + strIngredient6;
                    }
                    else
                    {
                        ingred6 = strIngredient6;
                    }
                    ingredients.Add(ingred6);
                }
                if (strIngredient7 != "")
                {
                    string ingred7 = "";

                    if (strMeasure7 != "\n")
                    {
                        ingred7 = strMeasure7 + " " + strIngredient7;
                    }
                    else
                    {
                        ingred7 = strIngredient7;
                    }
                    ingredients.Add(ingred7);
                }
                if (strIngredient8 != "")
                {
                    string ingred8 = "";

                    if (strMeasure8 != "\n")
                    {
                        ingred8 = strMeasure8 + " " + strIngredient8;
                    }
                    else
                    {
                        ingred8 = strIngredient8;
                    }
                    ingredients.Add(ingred8);
                }
                if (strIngredient9 != "")
                {
                    string ingred9 = "";

                    if (strMeasure9 != "\n")
                    {
                        ingred9 = strMeasure9 + " " + strIngredient9;
                    }
                    else
                    {
                        ingred9 = strIngredient9;
                    }
                    ingredients.Add(ingred9);
                }
                if (strIngredient10 != "")
                {
                    string ingred10 = "";

                    if (strMeasure10 != "\n")
                    {
                        ingred10 = strMeasure10 + " " + strIngredient10;
                    }
                    else
                    {
                        ingred10 = strIngredient10;
                    }
                    ingredients.Add(ingred10);
                }
                if (strIngredient11 != "")
                {
                    string ingred11 = "";

                    if (strMeasure11 != "\n")
                    {
                        ingred11 = strMeasure11 + " " + strIngredient11;
                    }
                    else
                    {
                        ingred11 = strIngredient11;
                    }
                    ingredients.Add(ingred11);
                }
                if (strIngredient12 != "")
                {
                    string ingred12 = "";

                    if (strMeasure12 != "\n")
                    {
                        ingred12 = strMeasure12 + " " + strIngredient12;
                    }
                    else
                    {
                        ingred12 = strIngredient12;
                    }
                    ingredients.Add(ingred12);
                }
                if (strIngredient13 != "")
                {
                    string ingred13 = "";

                    if (strMeasure13 != "\n")
                    {
                        ingred13 = strMeasure13 + " " + strIngredient13;
                    }
                    else
                    {
                        ingred13 = strIngredient13;
                    }
                    ingredients.Add(ingred13);
                }
                if (strIngredient14 != "")
                {
                    string ingred14 = "";

                    if (strMeasure14 != "\n")
                    {
                        ingred14 = strMeasure14 + " " + strIngredient14;
                    }
                    else
                    {
                        ingred14 = strIngredient14;
                    }
                    ingredients.Add(ingred14);
                }
                if (strIngredient15 != "")
                {
                    string ingred15 = "";

                    if (strMeasure15 != "\n")
                    {
                        ingred15 = strMeasure15 + " " + strIngredient15;
                    }
                    else
                    {
                        ingred15 = strIngredient15;
                    }
                    ingredients.Add(ingred15);
                }

                return ingredients;
            }
        }

        public string idDrink { get; set; }
        public string strDrink { get; set; }
        public string strCategory { get; set; }
        public string strIBA { get; set; }
        public string strAlcoholic { get; set; }
        public string strGlass { get; set; }
        public string strInstructions { get; set; }
        public string strDrinkThumb { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }
        public string strIngredient5 { get; set; }
        public string strIngredient6 { get; set; }
        public string strIngredient7 { get; set; }
        public string strIngredient8 { get; set; }
        public string strIngredient9 { get; set; }
        public string strIngredient10 { get; set; }
        public string strIngredient11 { get; set; }
        public string strIngredient12 { get; set; }
        public string strIngredient13 { get; set; }
        public string strIngredient14 { get; set; }
        public string strIngredient15 { get; set; }
        public string strMeasure1 { get; set; }
        public string strMeasure2 { get; set; }
        public string strMeasure3 { get; set; }
        public string strMeasure4 { get; set; }
        public string strMeasure5 { get; set; }
        public string strMeasure6 { get; set; }
        public string strMeasure7 { get; set; }
        public string strMeasure8 { get; set; }
        public string strMeasure9 { get; set; }
        public string strMeasure10 { get; set; }
        public string strMeasure11 { get; set; }
        public string strMeasure12 { get; set; }
        public string strMeasure13 { get; set; }
        public string strMeasure14 { get; set; }
        public string strMeasure15 { get; set; }
        public string dateModified { get; set; }
    }
}

