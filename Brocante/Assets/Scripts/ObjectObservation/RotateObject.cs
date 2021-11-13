using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{

    public float speed = 1200f;
    private bool isRotating = false;
    private Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        /*Move the object if the mouse move after a left click*/
        if (Input.GetMouseButtonDown(0)) {
            isRotating = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            isRotating = false;
        }

        if (isRotating) {
            rotation = new Vector3(Input.GetAxis("Mouse Y") * speed * Time.deltaTime, -1 * Input.GetAxis("Mouse X") * speed * Time.deltaTime, 0);
            transform.Rotate(rotation, Space.World);
        }
    }
}
