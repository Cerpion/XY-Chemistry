using UnityEngine;
using System.Collections.Generic;
public class ClientOrder : MonoBehaviour
{
    [SerializeField] private List<ItemID> items = new List<ItemID>();
    private ClientMovement clientMovement;
    public bool hasOrderInProgress;
    public ItemID costumeOrder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hasOrderInProgress = false;
        clientMovement = GetComponent<ClientMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (clientMovement.isInDeliveryStage && !hasOrderInProgress)
        {
            SelectOrder();
            hasOrderInProgress = true;
        }
    }

    private void SelectOrder()
    {
        int orderIndex = Random.Range(0, items.Count);
        costumeOrder = items[orderIndex];
    }
}
