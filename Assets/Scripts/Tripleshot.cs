using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripleshot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float powerupSpeed=3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -5)
        {
            transform.Translate(Vector3.down * Time.deltaTime * powerupSpeed);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player _player = other.transform.GetComponent<Player>();
            if (_player != null)
            {
                _player.ActivateTripleShot();
            }
            Destroy(this.gameObject);
        }
    }
}
