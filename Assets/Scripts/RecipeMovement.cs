using UnityEngine;
using UnityEngine.UI;

public class RecipeMovement : MonoBehaviour
{
    private Cauldron _cauldron;
    private ItemID _recipeID;

    [SerializeField] private float _rotationSpeed = 45;
    [SerializeField] private float _yLimit = 5;
    [SerializeField] private Image _icon;
    [SerializeField] private Material _backGroundColor;

    private void Update()
    {
        transform.GetChild(0).Rotate(Vector3.up * _rotationSpeed * Time.deltaTime, Space.Self);
    }

    public void Initialized(ItemData data, Cauldron cauldron)
    {
        _recipeID = data.ItemID;
        _icon.sprite = data.Icon;
        _backGroundColor.color = data.IconColor;

        _cauldron = cauldron;
    }

    public void MoveToDeliveryStage(Vector3 deliveryPos)
    {
        var newDeliveryPos = deliveryPos;
        newDeliveryPos.y = _yLimit;

        var sequence = LeanTween.sequence();
        sequence.append(LeanTween.moveY(gameObject, _yLimit, 1).setEaseInOutCubic());
        sequence.append(LeanTween.move(gameObject, newDeliveryPos, 0.1f));
        sequence.append(LeanTween.moveY(gameObject, deliveryPos.y, 1).setEaseInOutCubic());
        sequence.append(1f);

        sequence.append(OnSequenceFinished);
    }

    private void OnSequenceFinished()
    {
        _cauldron?.SendOrder.Invoke(_recipeID);
        Destroy(gameObject);
    }
}
