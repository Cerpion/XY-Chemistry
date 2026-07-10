using System;
using UnityEngine;
using UnityEngine.UI;

public class ClientMovement : MonoBehaviour
{
    public ClientData _clientData;

    public ItemData RequestedOrder;
    public Action<ItemData> OnClientOrder;
    public Action<float> OnClientTime;
    public Action OnFailedOrder;
    public Action OnClientExit;

    private Transform _deliveryStage;
    private Transform _exitStage;

    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _timeToWalk;
    [SerializeField] private AudioSource _audioSource;


    [SerializeField] private GameObject _canvas;
    [SerializeField] private Image _itemRequiered;

    private float _currentTime;
    private float _maxTime;

    private bool _isOrder;

    public void Initialized(Transform deliveryStage, Transform exitStage, ItemData itemToOder, float clientTime, ClientData clientStats)
    {
        _clientData = clientStats;

        _deliveryStage = deliveryStage;
        _exitStage = exitStage;

        _spriteRenderer.sprite = _clientData.Walk;
        _maxTime = clientTime;

        RequestedOrder = itemToOder;

        MoveToShop();
    }

    public void MoveToShop()
    {
        var sequence = LeanTween.sequence();
        sequence.append(LeanTween.move(gameObject, _deliveryStage, _timeToWalk).setEaseInOutCubic());
        sequence.append(PreOrder);
        sequence.append(2f);
        sequence.append(Order);
    }
    private void PreOrder()
    {
        _spriteRenderer.sprite = _clientData.Talk;

        _audioSource.clip = _clientData.Voice;
        _audioSource.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
        _audioSource.Play();

        _canvas.SetActive(true);
        _itemRequiered.sprite = RequestedOrder.Icon;
    }

    private void Order()
    {
        OnClientOrder?.Invoke(RequestedOrder);
        _spriteRenderer.sprite = _clientData.Walk;
        _canvas.SetActive(false);
        _isOrder = true;
    }


    public void ExitToShop()
    {
        var sequence = LeanTween.sequence();
        sequence.append(LeanTween.move(gameObject, _exitStage, _timeToWalk).setEaseInOutCubic());
        sequence.append(Exit);
    }


    private void Update()
    {
        if (!_isOrder)
        {
            return;
        }

        if (_currentTime > _maxTime)
        {
            OnFailedOrder?.Invoke();
            _isOrder = false;
            return;
        }

        _currentTime += Time.deltaTime;
        OnClientTime?.Invoke(_currentTime / _maxTime);
    }

    private void Exit()
    {
        OnClientExit?.Invoke();
        Destroy(gameObject);
    }
}
