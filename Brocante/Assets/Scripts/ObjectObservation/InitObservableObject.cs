using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitObservableObject : MonoBehaviour
{
    private static GameObject initGameObject;
    private Vector3 objectPosition = new Vector3(0,-3,17);
    [SerializeField] private Camera _camera;

    /*On instantie le gameObject contenu dans la variable static associée*/
    void Awake(){
        initGameObject = StaticObject.activeObject;
        Debug.Log(initGameObject);
        GameObject go = Instantiate(initGameObject, objectPosition, _camera.transform.rotation);
        go.GetComponent<ClickableObject>()._camera = _camera;
    }
}

public class StaticObject
{
    public static GameObject activeObject;
}
