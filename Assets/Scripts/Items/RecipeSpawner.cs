using System.Collections.Generic;
using UnityEngine;

public class RecipeSpawner : MonoBehaviour
{
    [SerializeField] private RecipesBox _recipesBox;
    private List<RecipesBox> _recipesBoxList = new List<RecipesBox>();


    public void SpawnRecipes(Recipe[] recipes)
    {
        foreach (Recipe currentRecipe in recipes)
        {
            var newRecipe = Instantiate(_recipesBox,transform);
            newRecipe.SetRecipe(currentRecipe);
            newRecipe.gameObject.SetActive(true);
            _recipesBoxList.Add(newRecipe);
        }
    }

    public void ClearRecipes()
    {
        for (int i = 0; i < _recipesBoxList.Count; i++)
        {
            Destroy(_recipesBoxList[i]);
        }

        _recipesBoxList.Clear();
    }
}
