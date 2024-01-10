using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField]
    private float enemyMoveSpeed;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (transform.position.y > -4.5f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * enemyMoveSpeed);
        }

        if (transform.position.y <= -4.5f)
        {
            transform.position = new Vector3(Random.Range(-8.5f, 8.5f), 6.5f, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit" + other.transform.name);
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.DamagePlayer();
            }
            Destroy(this.gameObject);
        }
    }
}