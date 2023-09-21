using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripleshot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
