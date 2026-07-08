using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class Mixer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private ICraftSystem craftSystem;
    [SerializeField] private RecipeConfiguration recipeConfiguration;
    [SerializeField] private ItemData trashData;
    [SerializeField] private int nClicksToMix;
    [SerializeField] private int nClicks;
    [SerializeField] private bool _craft;
    void Start()
    {
        nClicksToMix = 4;
        craftSystem = new CraftSystem(recipeConfiguration, trashData);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform == transform)
                {
                    nClicks += 1;
                }
                    
            }
        }

        if(nClicks >= nClicksToMix)
        {
            _craft = true;
            nClicks = 0;
        }

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
