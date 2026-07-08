using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeConfiguration", menuName = "Craft/RecipeConfiguration", order = 1)]
public class RecipeConfiguration : ScriptableObject
{
    public List<Recipe> Recipes;
}