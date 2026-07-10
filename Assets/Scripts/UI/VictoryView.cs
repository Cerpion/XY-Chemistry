using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryView : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    [SerializeField] Button _mainMenu;

    public void Awake()
    {
        _mainMenu.onClick.AddListener(ReturnMainMenu);
        _canvasGroup.alpha = 0;
    }

    public void Show()
    {
        LeanTween.cancel(_canvasGroup.gameObject);
        gameObject.SetActive(true);
        _canvasGroup.LeanAlpha(1, 0.3f).setIgnoreTimeScale(true);
    }

    public void Hide()
    {
        LeanTween.cancel(_canvasGroup.gameObject);
        _canvasGroup.LeanAlpha(0, 0.3f).setOnComplete(() => { gameObject.SetActive(false); });
    }
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
