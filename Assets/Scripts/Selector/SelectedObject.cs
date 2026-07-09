using System;
using UnityEngine;

public abstract class SelectedObject : MonoBehaviour
{
    [SerializeField] private ItemSelectable _hover;

    public bool BlocksInteraction;
    public Action OnFinished;

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
}
