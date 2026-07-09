using System.Collections.Generic;
using UnityEngine;

public interface ICraftSystem
{
    public ItemData Craft();
    public void AddItem(ItemData item);
}

public class CraftSystem : ICraftSystem
{
    private readonly RecipeConfiguration _recipeConfiguration;
    private readonly ItemData _trash;
    private List<ItemID> _input;

    public CraftSystem(RecipeConfiguration recipeConfiguration, ItemData trash)
    {
        _recipeConfiguration = recipeConfiguration;
        _trash = trash;
        _input = new List<ItemID>();
    }

    public ItemData Craft()
    {
        var recipe = FindRecipe();

        if (recipe == null)
        {
            _input.Clear();
            return _trash;
        }

        _input.Clear();
        return recipe.Output;

    }

    public Recipe FindRecipe()
    {
        foreach (var currentRecipe in _recipeConfiguration.Recipes)
        {
            if (_input.Count != currentRecipe.Input.Count)
            {
                Debug.Log($"la receta {currentRecipe.Output.Name} no tiene la misma contaidad");
                continue;
            }

            List<ItemData> remainingIngredients = new(currentRecipe.Input);

            foreach (var itemInput in _input)
            {
                for (int i = 0; i < remainingIngredients.Count; i++)
                {
                    if (remainingIngredients[i].ID == itemInput.ID)
                    {
                        remainingIngredients.RemoveAt(i);
                        break;
                    }
                }
            }

            if (remainingIngredients.Count == 0)
            {
                return currentRecipe;
            }
        }

        return null;
    }

    public void AddItem(ItemData item)
    {
        _input.Add(item.ItemID);
    }
}