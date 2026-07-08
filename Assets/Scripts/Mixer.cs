using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Mixer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ICraftSystem craftSystem;
    [SerializeField] private RecipeConfiguration recipeConfiguration;
    [SerializeField] private ItemData trashData;
    void Start()
    {
        craftSystem = new CraftSystem(recipeConfiguration, trashData);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddComponent(ItemData item)
    {
        craftSystem.AddItem(item);
    }
}
