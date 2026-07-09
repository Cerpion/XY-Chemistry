using UnityEngine;

public class ClientMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject deliveryStage;
    private GameObject exitStage;
    private Vector3 deliveryPosition;
    private Vector3 exitPosition;
    public bool isInDeliveryStage;
    public bool canGoToExit;

    [SerializeField] private float speedMovement;

    private ClientSpawner clientSpawn;

    void OnEnable()
    {
        deliveryStage = GameObject.FindGameObjectWithTag("PointToReceiveDelivery");
        exitStage = GameObject.FindGameObjectWithTag("PointToExit");
        clientSpawn = GameObject.Find("ClientSpawner").GetComponent<ClientSpawner>();
        isInDeliveryStage = false;

        if (deliveryStage != null)
        {
            deliveryPosition = new Vector3(deliveryStage.transform.position.x, transform.position.y, transform.position.z);
        }

        if (exitStage != null)
        {
            exitPosition = new Vector3(exitStage.transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(deliveryStage != null && !isInDeliveryStage)
        {
            transform.position = Vector3.MoveTowards( transform.position, deliveryPosition, speedMovement * Time.deltaTime);
            if (transform.position == deliveryPosition)
            {
                isInDeliveryStage = true;

            }
            
        }

        if (canGoToExit && exitStage != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, exitPosition, speedMovement * Time.deltaTime);
            if (transform.position == exitPosition)
            {
                
                Destroy(gameObject);
                clientSpawn.SpawnClient();



            }
        }
        
    }
}
