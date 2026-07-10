using UnityEngine;

public class Potion : SelectedObject
{
    [SerializeField] private ItemData itemData;

    [SerializeField] private float _offset = 3f;
    [SerializeField] private float _zOffset = 0;
    [SerializeField] private float _moveSpeed = 8f;

    private Rigidbody componentRb;
    private Vector3 _startPosition;

    
    void Start()
    {
        _startPosition = transform.position;
        componentRb = GetComponent<Rigidbody>();
    }

    public void SetDefaultPosition()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mixer"))
        {
            Cauldron mixer = collision.gameObject.GetComponent<Cauldron>();

            if(mixer != null)
            {
                mixer.AddComponent(itemData);
            }
        }
        SetDefaultPosition();
    }

    public override void StartInteraction()
    {
        componentRb.isKinematic = true;
        LeanTween.moveY(gameObject, transform.position.y + _offset, 0.2f).setEaseOutBack();
        LeanTween.moveZ(gameObject, transform.position.z + _zOffset, 0.2f);
    }

    public override void EndInteraction()
    {
        componentRb.isKinematic = false;
    }

    public override void UpdateObject(Vector2 position)
    {
        Vector3 target = transform.position;
        target.x = position.x;
        transform.position = Vector3.Lerp(transform.position, target, _moveSpeed * Time.deltaTime);
    }
}
