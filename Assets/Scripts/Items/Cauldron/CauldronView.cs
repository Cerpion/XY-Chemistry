using UnityEngine;
using UnityEngine.UI;

public class CauldronView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Image _visualBar;

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _visualBar.transform.localScale = new Vector3(0, 1, 1); 
    }

    public void UpdateBar(float normalizedValue)
    {
        _visualBar.transform.LeanScaleX(normalizedValue, 0.2f);
    }

    public void Show()
    {
        _canvasGroup.LeanAlpha(1, 0.2f);
    }

    public void Hide()
    {
        _canvasGroup.LeanAlpha(0, 0.2f);
    }
}