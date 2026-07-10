using System;
using UnityEngine;

public class Cauldron : SelectedObject
{
    private ICraftSystem _craftSystem;
    [SerializeField] private RecipeConfiguration _recipeConfiguration;
    [SerializeField] private ItemData _trashData;

    [SerializeField] private CauldronView _cauldronView;

    [SerializeField] private Transform _delivery;

    [SerializeField] private int _maxClicksToMix = 4;
    private int _currentClicks;

    public Action<ItemID> SendOrder;

    void Start()
    {
        _maxClicksToMix = 4;
        _craftSystem = new CraftSystem(_recipeConfiguration, _trashData);
    }

    public void AddComponent(ItemData item)
    {
        _craftSystem.AddItem(item);
        Bouncing();
    }

    private void Bouncing()
    {
        transform.LeanScale(Vector3.one * 1.2f, 0.1f).setOnComplete(() =>
        {
            transform.LeanScale(Vector3.one, 0.15f).setEaseOutBack();
        });
    }

    public override void StartInteraction()
    {
        if (!_craftSystem.CanCraft())
        {
            return;
        }

        Bouncing();
        _currentClicks += 1;
        _cauldronView.Show();
        _cauldronView.UpdateBar((float)_currentClicks / _maxClicksToMix);

        if (_currentClicks >= _maxClicksToMix)
        {
            var craftItem = _craftSystem.Craft();

            var recipeObject = Instantiate(craftItem.Prefab, transform);

            var recipeMovement = recipeObject.GetComponent<RecipeMovement>();
            recipeMovement.Initialized(craftItem,this);
            recipeMovement.MoveToDeliveryStage(_delivery.position);

            _currentClicks = 0;
            _cauldronView.Hide();
            _cauldronView.UpdateBar(0);
        }
    }

    public override void EndInteraction()
    {
    }

    public override void UpdateObject(Vector2 position)
    {
    }
}