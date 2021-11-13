using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderReputation : MonoBehaviour
{
    private Slider _slider;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = StockingRessources.GetMaxRep();
        _slider.minValue = StockingRessources.GetMinRep();

    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = StockingRessources.GetReputation();
    }
}
