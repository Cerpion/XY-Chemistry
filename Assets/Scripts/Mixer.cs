using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Mixer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private List<string> components = new List<string>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddComponent(string component)
    {
        components.Add(component);
    }
}
