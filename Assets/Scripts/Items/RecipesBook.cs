using Unity.Cinemachine;
using UnityEngine;

public class RecipesBook : SelectedObject
{
    [SerializeField] private CinemachineCamera _recipeCamera;
    [SerializeField] private CinemachineCamera _normalCamera;
    [SerializeField] private CanvasGroup _RecipeBook;

    private void Awake()
    {
        _RecipeBook.alpha = 0;
    }

    public override void StartInteraction()
    {
        _recipeCamera.Priority = 10;
        _normalCamera.Priority = 5;
        _RecipeBook.gameObject.SetActive(true);

        _RecipeBook.LeanAlpha(1, 0.2f).setDelay(0.8f);
    }

    public override void EndInteraction()
    {
        _normalCamera.Priority = 10;
        _recipeCamera.Priority = 5;
        _RecipeBook.gameObject.SetActive(false);

        _RecipeBook.LeanAlpha(0, 0.2f).setDelay(0.8f).setOnComplete(() =>
        {
            //OnFinished?.Invoke();
        });
    }

    public override void UpdateObject(Vector2 position)
    {
    }
}
