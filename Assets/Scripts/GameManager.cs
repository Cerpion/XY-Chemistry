using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    [SerializeField] private int gameLevel;
    [SerializeField] private int numberPlayerLifes;
    [SerializeField] private float numberOrdersByDay;
    [SerializeField] private int numberOrdersBasicsByDay = 4;
    [SerializeField] private float difficultyIncreaseRate = 0.4f;
    [SerializeField] private int numberSuccessfulOrders;
    Component[] components;
    public bool isAnyComponentSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameLevel = 0;
        numberSuccessfulOrders = 0;
        numberOrdersByDay = numberOrdersBasicsByDay;
        isAnyComponentSelected = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SumarVida(int amount)
    {
        numberPlayerLifes += amount;
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
        numberOrdersByDay = Mathf.RoundToInt(numberOrdersBasicsByDay + (1 *(gameLevel * difficultyIncreaseRate)));
        numberSuccessfulOrders = 0;
    }

    public void CompareRecipes(ItemID recipeID)
    {
        ClientOrder clientOrder = FindAnyObjectByType<ClientOrder>();
        ClientMovement clientMovement = FindAnyObjectByType<ClientMovement>();
        if (clientOrder != null)
        {
            if (recipeID != clientOrder.costumeOrder)
            {
                numberPlayerLifes += -1;
            }
            else
            {
                numberSuccessfulOrders += 1;
            }

            clientMovement.canGoToExit = true;
        }
        
    }
}
