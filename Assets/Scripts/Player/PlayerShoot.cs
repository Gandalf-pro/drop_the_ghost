using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody body;
    // Start is called before the first frame update
    void FixedUpdate() {
        // Physics.Raycast(body.transform.position,-Vector3.up,out hit)
        Ray playerRay = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
