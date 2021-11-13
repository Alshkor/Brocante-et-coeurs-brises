using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    private Animator anim;
    private AudioSource audioData;
    private bool isActiveAudio = true;
    public Camera _camera;

    // Update is called once per frame
    void Update()
    {
        /*On utilise le Raycast pour regarder sur quel collider on clique*/
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

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
            /*Si on clique sur la manivelle : on ouvre la boître et on joue de la musique*/
            case "BoxOpener":
                Debug.Log("Box Opener Trigger");
                anim = gameObject.GetComponent<Animator>();
                anim.SetTrigger("Open");
                break;
            /*Si on appuie sur le bouton dans la boite : on joue de la musique*/
            case "BoxButton":
                Debug.Log("BoxButton Trigger");
                if (isActiveAudio) {
                    Debug.Log("Music Play");
                    audioData = gameObject.GetComponent<AudioSource>();
                    audioData.Play(0);
                    isActiveAudio = false;
                }
                break;
            /*Si on clique sur le cadenas : le livre s'ouvre*/
            case "Cadenas":
                Debug.Log("Book Open Trigger");
                anim = gameObject.GetComponent<Animator>();
                anim.SetTrigger("Open");
                break;
            /*default : on ne fait rien*/
            default:
                Debug.Log("Default switch state");
                break;
        }
    }
}
