using UnityEngine;
using UnityEngine.UI;

public class RecipeView : MonoBehaviour
{
    [SerializeField] private Image _character;
    [SerializeField] private Image _item;
    [SerializeField] private Image _timer;
    [SerializeField] private RectTransform _view;

    private void Awake()
    {
        _view.position = new Vector3(455, _view.position.y, _view.position.z);
    }

    public void SetView(ItemData item, ClientData client)
    {
        _character.sprite = client.Walk;
        _item.sprite = item.Icon;
        _timer.fillAmount = 0;
        _view.position = new Vector3(455, _view.position.y, _view.position.z);
    }

    public void Show()
    {
        LeanTween.moveX(_view,0, 0.4f).setEaseOutBack();
    }

    public void UpdateFill(float value)
    {
        _timer.fillAmount = value;
    }

    public void Hide()
    {
        LeanTween.moveX(_view, 455, 0.6f).setEaseInBack();
    }
}
