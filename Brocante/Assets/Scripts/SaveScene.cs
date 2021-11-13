using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
    }

    public void DisactiveScene()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    
    public void ActiveScene()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
}
