using TMPro;
using UnityEngine;

public class NextDay : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        _canvasGroup.alpha = 0;
    }

    public void Show(int day)
    {
        _text.text = $"Día {day}";
        LeanTween.cancel(_canvasGroup.gameObject);
        gameObject.SetActive(true);
        _canvasGroup.LeanAlpha(1, 0.5f).setIgnoreTimeScale(true);
    }

    public void Hide()
    {
        LeanTween.cancel(_canvasGroup.gameObject);
        _canvasGroup.LeanAlpha(0, 0.5f).setOnComplete(() => { gameObject.SetActive(false); });
    }
}
