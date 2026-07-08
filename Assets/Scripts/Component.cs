using UnityEngine;
using UnityEngine.InputSystem;

public class Component : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Vector3 offset = new Vector3(0, 0.2f, 0);
    public bool isSelected = false;
    [SerializeField] private Vector3 originalPos;
    [SerializeField] private Quaternion originalRot;
    [SerializeField] private float moveSpeed = 0.01f;
    private Rigidbody componentRb;
    [SerializeField] private string nameComponent;
    private GameManager gameManager;
    //[SerializeField] private ItemData itemData;
    
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;
        componentRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // If ray hit this enemy, destroy it
                if (hit.transform == transform && !isSelected && !gameManager.isAnyComponentSelected)
                {
                    
                    transform.position = transform.position + offset;
                    isSelected = true;
                    gameManager.IsAnyObjectSelected();
                    componentRb.isKinematic = true;
                }
                else
                {
                    componentRb.isKinematic = false;
                    isSelected = false;
                }
                

            }
        }

        if (isSelected)
        {
            //SetDefaultPosition();
            //isSelected = false;

            float deltaX = Mouse.current.delta.ReadValue().x;

            transform.position += new Vector3(deltaX * moveSpeed, 0f, 0f);
        }
    }

    public void SetDefaultPosition()
    {
        transform.position = originalPos;
        transform.rotation = originalRot;
        isSelected = false;
        gameManager.IsAnyObjectSelected();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mixer"))
        {
            Mixer mixer = collision.gameObject.GetComponent<Mixer>();

            if(mixer != null)
            {
                //mixer.AddComponent(itemData);
            }
        }
        SetDefaultPosition();
    }
}
