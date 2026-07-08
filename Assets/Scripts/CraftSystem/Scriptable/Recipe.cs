using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "Craft/Recipe", order = 0)]
public class Recipe : ScriptableObject
{
    public List<ItemData> Input;
    public ItemData Output;
}
