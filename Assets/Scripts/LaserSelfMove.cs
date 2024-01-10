using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSelfMove : MonoBehaviour
{
    
    [SerializeField]
    private float laserSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate (Vector3.up * Time.deltaTime * laserSpeed);
        if (transform.position.y > 10)
        {
            if (transform.parent != null)
                Destroy(transform.parent.gameObject);
            Destroy (gameObject);
        }
    }
}
