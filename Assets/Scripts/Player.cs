using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float SpeedMultiplier;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput   = Input.GetAxis("Horizontal");
        float verticalInput     = Input.GetAxis("Vertical");

        if (transform.position.x > 9)
        {
            transform.position = new Vector3(9, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -9)
        {
            transform.position = new Vector3(-9, transform.position.y, transform.position.z);

        }


        transform.Translate(new Vector3(1, 0, 0) * horizontalInput * Time.deltaTime * SpeedMultiplier);
        transform.Translate(new Vector3(0, 1, 0) * verticalInput * Time.deltaTime * SpeedMultiplier);

    }
}
