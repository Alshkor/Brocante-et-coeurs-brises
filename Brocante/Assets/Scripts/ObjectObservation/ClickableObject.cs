using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Animator anim;

    // Update is called once per frame
    void Update()
    {
        /*On utilise le Raycast pour regarder sur quel collider on clique*/
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {

                Debug.Log("On a touché : " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "eventTrigger"){
                    Debug.Log("C'est un trigger");
                    ObjectEvent(hit.transform.gameObject.name);
                } 
            }

            //Debug.DrawLine(transform.position, hit.point, Color.red);  
        }
    }

    /*Fonction qui gère les différents événements en fonction de où l'on touche l'objet*/
    void ObjectEvent(string objectName){
        switch (objectName){
            case "BoxOpener":
                Debug.Log("Box Opener Trigger");
                anim = gameObject.GetComponent<Animator>();
                anim.SetTrigger("Open");
                break;
            case "BoxButton":
                Debug.Log("BoxButton Trigger");
                break;
            default:
                Debug.Log("Default switch state");
                break;
        }
    }
}