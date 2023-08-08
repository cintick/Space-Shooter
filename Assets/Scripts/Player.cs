using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float SpeedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // wrap player around in X axis. ( exiting from left of the screen and teleporting right )
        if (transform.position.x > 11.35)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -11.35)
        {
            transform.position = new Vector3(11.3f, transform.position.y, transform.position.z);
        }

        // restrict player to only moving between zero and bottom of the screen with Mathf.Clamp
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.85f, 0), 0);

        //move player with the speed multipler in horizontal and vertical axises
        transform.Translate(new Vector3(1, 0, 0) * horizontalInput * Time.deltaTime * SpeedMultiplier);
        transform.Translate(new Vector3(0, 1, 0) * verticalInput * Time.deltaTime * SpeedMultiplier);
    }
}
