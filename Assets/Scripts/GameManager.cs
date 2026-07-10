using UnityEngine;
public class GameManager : MonoBehaviour
{
    [SerializeField] private DayConfiguration _day;

    [SerializeField] private ClientSpawner _clientSpawner;

    [SerializeField] private Cauldron _cauldron;

    [SerializeField] private int gameLevel;
    [SerializeField] private int numberPlayerLifes;
    [SerializeField] private float numberOrdersByDay;
    [SerializeField] private int numberOrdersBasicsByDay = 4;
    [SerializeField] private float difficultyIncreaseRate = 0.4f;
    [SerializeField] private int numberSuccessfulOrders;
    Potion[] components;
    public bool isAnyComponentSelected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _day = Instantiate(_day);

        _cauldron.SendOrder += CompareRecipes;

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
        components = FindObjectsByType<Potion>(FindObjectsSortMode.None);
        if (components.Length > 0)
        {
            
            foreach (Potion component in components)
            {
                //if (component.isSelected)
                //{
                //    //Debug.Log("Si encontro");
                //    isAnyComponentSelected = true;
                //    break;
                //}
                //else
                //{
                //    isAnyComponentSelected = false;
                //}
            }
        }
    }

    public void IncreaseDificulty()
    {
        gameLevel += 1;
        numberOrdersByDay = Mathf.RoundToInt(numberOrdersBasicsByDay + (1 *(gameLevel * difficultyIncreaseRate)));
        numberSuccessfulOrders = 0;
    }

    public void CompareRecipes(ItemID itemDelivered)
    {
        if (itemDelivered.ID == _clientSpawner.CurrentClient.RequestedOrder.ID)
        {
            numberSuccessfulOrders += 1;

            return;
        }

        numberPlayerLifes += -1;


        if (numberPlayerLifes <= 0)
        {
            Debug.Log("GameOver");
        }
    }
}
