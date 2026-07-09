using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    [SerializeField] private int gameLevel;
    [SerializeField] private int nLifes;
    [SerializeField] private float nOrder;
    [SerializeField] private int nOrderBasic = 4;
    [SerializeField] private float difIncreaseRate = 0.4f;
    Component[] components;
    public bool isAnyComponentSelected;
    [SerializeField] private List<string> costumeOrder = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameLevel = 0;
        nOrder = nOrderBasic;
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
                    //Debug.Log("Si encontro");
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

    public void IncreaseDificulty()
    {
        gameLevel += 1;
        nOrder = Mathf.RoundToInt(nOrderBasic + (1 *(gameLevel * difIncreaseRate)));
    }
}
