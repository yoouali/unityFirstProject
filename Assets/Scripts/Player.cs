using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyPress = false;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;

    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start(){
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Space key presdown");
            jumpKeyPress = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    //FixeUpdate is called once every physics Update
    private void FixedUpdate()
    {
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }
        if (jumpKeyPress == true)
        {
            Debug.Log("jump phisiq aplied");
            rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
            jumpKeyPress = false;
        }

        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, rigidbodyComponent.velocity.z);
    }

}