using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {

                if (hit.transform.gameObject.tag == "eventTrigger"){
                    Debug.Log("TouchéTrigger");
                } else {
                    Debug.Log("on a touché : " + hit.transform.gameObject.tag);
                }

            }

            Debug.DrawLine(transform.position, hit.point, Color.red);  
        }
    }
}
