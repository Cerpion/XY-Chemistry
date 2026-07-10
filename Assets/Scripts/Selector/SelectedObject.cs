using System;
using UnityEngine;

public abstract class SelectedObject : MonoBehaviour
{
    [SerializeField] private ItemSelectable _hover;

    public void HoverEnter()
    {
        _hover.Select();
    }

    public void HoverExit()
    {
        _hover.Deselect();
    }

    public abstract void StartInteraction();
    public abstract void EndInteraction();
    public abstract void UpdateObject(Vector2 position);
}
