using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    [SerializeField] private int gameLevel;
    [SerializeField] private int nLifes;
    Component[] components;
    public bool isAnyComponentSelected;
    [SerializeField] private List<string> costumeOrder = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isAnyComponentSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarVida(int amount)
    {
        nLifes += amount;
    }

    public void IsAnyObjectSelected()
    {
        components = FindObjectsByType<Component>(FindObjectsSortMode.None);
        if (components.Length > 0)
        {
            
            foreach (Component component in components)
            {
                if (component.isSelected)
                {
                    Debug.Log("Si encontro");
                    isAnyComponentSelected = true;
                    break;
                }
                else
                {
                    isAnyComponentSelected = false;
                }
            }
        }
    }
}
