using UnityEngine;

public class CraftConsumer : MonoBehaviour
{

    public bool addItem;
    public bool craft;

    public ICraftSystem craftSystem ;

    public RecipeConfiguration _recipes;
    public ItemData _trash;
    public ItemData _itemToAdd;

    void Start()
    {
        craftSystem = new CraftSystem(_recipes, _trash);
    }

    void Update()
    {
        if (craft)
        {
            var craftItem = craftSystem.Craft();
            Debug.Log(craftItem.ID);
            craft = false;
        }

        if (addItem)
        {
            craftSystem.AddItem(_itemToAdd);
            _itemToAdd = null;
            addItem = false;
        }
    }
}
