using System;
using UnityEngine;

public class LifeView : MonoBehaviour
{
    [SerializeField] private Animator[] life;

    public void Damage(int currentLife)
    {
        if (currentLife < 0 || currentLife >= life.Length)
            return;

        life[currentLife].SetTrigger("Damage");
    }

}
