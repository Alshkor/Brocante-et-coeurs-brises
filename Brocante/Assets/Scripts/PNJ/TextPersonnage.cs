using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPersonnage : MonoBehaviour
{
    private static Text _text;
    
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void UpdateSentence(string newSentence)
    {
        _text.text = newSentence;
    }
    
}
