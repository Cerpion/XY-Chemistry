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

        LeanTween.cancel(_RecipeBook.gameObject);
        _RecipeBook.LeanAlpha(1, 0.8f);
    }

    public override void EndInteraction()
    {
        _normalCamera.Priority = 10;
        _recipeCamera.Priority = 5;

        LeanTween.cancel(_RecipeBook.gameObject);
        _RecipeBook.LeanAlpha(0, 0.8f).setOnComplete(() =>
        {
            _RecipeBook.gameObject.SetActive(false);
        });
    }

    public override void UpdateObject(Vector2 position)
    {
    }
}
