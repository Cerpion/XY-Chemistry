using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public void Show()
    {
        _canvasGroup.gameObject.SetActive(true);
        _canvasGroup.LeanAlpha(1, 0.3f);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}