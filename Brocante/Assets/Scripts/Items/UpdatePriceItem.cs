using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePriceItem : MonoBehaviour
{
    private Text _text;
    
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("selection " + IsItemSelect.IsItemAlreadySelect());
        float prix = IsItemSelect.GetPriceItemSelected();
        if (prix > -1)
        {
            _text.text = "Prix : " + prix;
        }
        else
        {
            _text.text = "Prix : ";
        }


    }
}
