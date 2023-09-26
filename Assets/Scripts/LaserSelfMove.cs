using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSelfMove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float laserSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
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
