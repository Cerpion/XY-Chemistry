using UnityEngine;

public class ItemSelectable : MonoBehaviour
{
    [SerializeField] private GameObject _normal;
    [SerializeField] private GameObject _hover;

    public void Select()
    {
        _normal.SetActive(false);
        _hover.SetActive(true);
    }

    public void Deselect()
    {
        _normal.SetActive(true);
        _hover.SetActive(false);
    }
}
