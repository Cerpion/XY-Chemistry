using System;
using UnityEngine;

public class ClientMovement : MonoBehaviour
{
    public ItemID RequestedOrder;
    public Action OnClientExit;

    private Transform _deliveryStage;
    private Transform _exitStage;

    [SerializeField] private float _timeToWalk;
    [SerializeField] private AudioClip[] _talkClip;
    [SerializeField] private AudioSource _audioSource;

    public void Initialized(Transform deliveryStage, Transform exitStage)
    {
        _deliveryStage = deliveryStage;
        _exitStage = exitStage;
        MoveToShop();
    }

    public void MoveToShop()
    {
        var sequence = LeanTween.sequence();
        sequence.append(LeanTween.move(gameObject, _deliveryStage, _timeToWalk).setEaseInOutCubic());
        sequence.append(Order);
        sequence.append(2f);
    }
    private void Order()
    {
        _audioSource.clip = _talkClip[UnityEngine.Random.Range(0, _talkClip.Length)];
        _audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        _audioSource.Play();

        //Ordenar
        //UI
        //CambiarImagen
    }

    public void ExitToShop()
    {
        var sequence = LeanTween.sequence();
        sequence.append(LeanTween.move(gameObject, _exitStage, _timeToWalk).setEaseInOutCubic());
        sequence.append(Exit);
    }

    private void Exit()
    {
        OnClientExit?.Invoke();
        Destroy(gameObject);
    }
    public void SelectOrder(ItemID itemToOder)
    {
        RequestedOrder = itemToOder;
    }

}
