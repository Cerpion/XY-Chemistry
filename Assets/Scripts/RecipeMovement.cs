using NUnit.Framework.Interfaces;
using UnityEngine;
using UnityEngine.Rendering;

public class RecipeMovement : MonoBehaviour
{
    private GameObject delieverStage;
    [SerializeField] private float yLimit;
    [SerializeField] private bool canFall = false;
    [SerializeField] private bool canMove = true;
    [SerializeField] private float raiseSpeed;
    [SerializeField] private float fallSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        delieverStage = GameObject.FindGameObjectWithTag("DelieverStage");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= yLimit && !canFall)
        {
            transform.Translate(Vector3.up * raiseSpeed * Time.deltaTime);

        }

        if(transform.position.y >= yLimit)
        {
            transform.position = new Vector3(delieverStage.transform.position.x, yLimit, delieverStage.transform.position.z);
            canFall = true;

        }

        if (canFall)
        {
            transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DelieverStage"))
        {
            Debug.Log("Entro");
            Destroy(gameObject);
        }
    }


}
