using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float SpeedMultiplier;
    [SerializeField]
    private Transform laserPrefab;
    [SerializeField]
    private float laserCooldown;
    private float laserTimer = -1f;
    [SerializeField]
    private int playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        PlayerShootLaser();

    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // wrap player around in X axis. ( exiting from left of the screen and teleporting right )
        if (transform.position.x > 9.5)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -9.5)
        {
            transform.position = new Vector3(9.5f, transform.position.y, transform.position.z);
        }

        // restrict player to only moving between zero and bottom of the screen with Mathf.Clamp
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.85f, 0), 0);

        //move player with the speed multipler in horizontal and vertical axises
        transform.Translate(new Vector3(1, 0, 0) * horizontalInput * Time.deltaTime * SpeedMultiplier);
        transform.Translate(new Vector3(0, 1, 0) * verticalInput * Time.deltaTime * SpeedMultiplier);
    }
    void PlayerShootLaser()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > laserTimer)
        {
            Instantiate(laserPrefab, new Vector3(transform.position.x, (transform.position.y + 0.8f)), transform.rotation);
            laserTimer = Time.time + laserCooldown;
        }
    }
    
    public void DamagePlayer()
    {
            playerLives--;
            if (playerLives == 0)
            {
            Debug.Log("Game Over, Thanks for Playing");
            Destroy(this.gameObject);
            }
    }
}
