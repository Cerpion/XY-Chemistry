using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RecipesBox : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private Image _icon;
    [SerializeField] private Image[] _items;
    [SerializeField] private TMP_Text[] _pluss;

    public void SetRecipe(Recipe recipe)
    {
        _name.text = recipe.name;
        _icon.sprite = recipe.Output.Icon;

        foreach (var item in _items)
        {
            item.gameObject.SetActive(false);
        }

        for (var i = 0; i < recipe.Input.Count; i++)
        {
            _items[i].sprite = recipe.Input[i].Icon;
            _items[i].gameObject.SetActive(true);
        }

        foreach (var pluss in _pluss)
        {
            pluss.gameObject.SetActive(false);
        }

        for (var i = 0; i < recipe.Input.Count - 1; i++)
        {
            _pluss[i].gameObject.SetActive(true);
        }
    }

  
}