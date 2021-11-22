using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody body;
    public float forwardForce = 2000f;
    public float sidewayForce = 100f;
    public float jumpHeight = 1000f;
    private bool spacePressed = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float localForwadForce = this.forwardForce;

        if(Input.GetKey(KeyCode.LeftShift)){
            localForwadForce *= 1.5f;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            this.spacePressed = true;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            this.spacePressed = false;
        }
        if(this.spacePressed){
            this.spacePressed = false;
            // Vector3 newPos = body.position + new Vector3(0, jumpHeight, 0);
            // if(newPos.y > 28){
            //     newPos.y = 25;
            // }
            // body.position = newPos;
            body.AddForce(0, jumpHeight, 0);
        }

        // if(Input.GetKey("w")){
        //     body.AddForce(0, 0, localForwadForce * Time.deltaTime);
        // }
        // if(Input.GetKey("s")){
        //     body.AddForce(0, 0, this.forwardForce * Time.deltaTime * -1);
        // }
        // if(Input.GetKey("d")){
        //     body.AddForce(this.sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // }
        // if(Input.GetKey("a")){
        //     body.AddForce(-this.sidewayForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        // }

        // float moveHorizantal = Input.GetAxisRaw("Horizontal");
        // float moveVertical = Input.GetAxisRaw("Vertical");

        // Vector3 movement = new Vector3(moveHorizantal, 0.0f, moveVertical);

        // body.AddForce(movement * localForwadForce);


        // Look at

        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 groundLevel = Vector3.up;
        groundLevel.y = body.position.y - 1;
        Plane groundPlane = new Plane(groundLevel, groundLevel);
        float rayLenght;

        if(groundPlane.Raycast(mouseRay, out rayLenght)){
            Vector3 pointToLook = mouseRay.GetPoint(rayLenght);
            Debug.DrawLine(mouseRay.origin, pointToLook, Color.blue);
            Vector3 lookPoint = new Vector3(pointToLook.x, body.transform.position.y, pointToLook.z);
            body.transform.LookAt(lookPoint);
            body.position = Vector3.MoveTowards(body.position, lookPoint, localForwadForce * Time.deltaTime);
        }

    }
}
