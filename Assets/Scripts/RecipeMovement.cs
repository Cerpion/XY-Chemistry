using NUnit.Framework.Interfaces;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

public class RecipeMovement : MonoBehaviour
{
    private GameObject delieverStage;
    [SerializeField] private float yLimit;
    [SerializeField] private bool canFall = false;
    [SerializeField] private float raiseSpeed;
    [SerializeField] private float fallSpeed;
    private Rigidbody componentRb;
    public ItemID recipeID;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        delieverStage = GameObject.FindGameObjectWithTag("DelieverStage");
        componentRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y <= yLimit && !canFall)
        {
            transform.Translate(Vector3.up * raiseSpeed * Time.deltaTime);

        }

        
        if(transform.localPosition.y >= yLimit)
        {
            transform.position = new Vector3(delieverStage.transform.position.x, yLimit, delieverStage.transform.position.z);
            canFall = true;

        }

        
        if (canFall)
        {
            componentRb.isKinematic = false;
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DelieverStage"))
        {
            Debug.Log("Entro");
            gameManager.CompareRecipes(recipeID);
            Destroy(gameObject);
        }
    }
    
    public void DefineRecipeID(ItemID id)
    {
        recipeID = id;
    }

}
