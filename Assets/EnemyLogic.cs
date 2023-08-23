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

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > -5.5f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * enemyMoveSpeed);
        }

        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(Random.Range(-9.5f, 9.5f), 8f, 0);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit" + other.transform.name);
        if (other.CompareTag("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            Destroy(GameObject.FindWithTag("Player"));
            other.transform.GetComponent<Player>().DamagePlayer();
            Destroy(this.gameObject);
        }
    }
}
