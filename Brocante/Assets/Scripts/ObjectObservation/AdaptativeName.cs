using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptativeName : MonoBehaviour
{
    private GameObject objectUsed;

    /*On change le nom de la description par le nom de l'objet actif*/
    void Awake(){
        objectUsed = StaticObject.activeObject;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = objectUsed.name;
        Debug.Log("Nom de la description basée sur : " + objectUsed);
    }
}