using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitObservableObject : MonoBehaviour
{
    private static GameObject initGameObject;
    private Vector3 objectPosition = new Vector3(0,-3,17);

    /*On instantie le gameObject contenu dans la variable static associée*/
    void Awake(){
        initGameObject = StaticObject.activeObject;
        Debug.Log(initGameObject);
        GameObject.Instantiate(initGameObject, objectPosition, Camera.main.transform.rotation);
    }
}

public class StaticObject
{
    public static GameObject activeObject;
}
