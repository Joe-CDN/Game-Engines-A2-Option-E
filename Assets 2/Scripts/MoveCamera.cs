using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public CharacterController controller;
    Vector3 moveDir;

    float horizontal;
    float vertical;
    public float speed = 6f;
    
    // Update is called once per frame
    void Update()
    {
        if(InputPlane.editMode == true)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            moveDir = new Vector3(horizontal, vertical, 0f).normalized;

            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }        
    }
}
