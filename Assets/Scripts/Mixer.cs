using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using static UnityEditor.Progress;

public class Mixer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ICraftSystem craftSystem;
    [SerializeField] private RecipeConfiguration recipeConfiguration;
    [SerializeField] private ItemData trashData;

    [SerializeField] private bool _craft;
    void Start()
    {
        craftSystem = new CraftSystem(recipeConfiguration, trashData);
    }

    // Update is called once per frame
    void Update()
    {
        if (_craft)
        {
            var item = craftSystem.Craft();
            Debug.Log(item.ID);
            Instantiate(item.Prefab,transform);
            _craft = false;
        }
    }

    public void AddComponent(ItemData item)
    {
        Debug.Log("Entro");
        craftSystem.AddItem(item);
    }
}
