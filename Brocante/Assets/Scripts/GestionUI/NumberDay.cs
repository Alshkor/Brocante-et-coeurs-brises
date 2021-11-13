using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberDay : MonoBehaviour
{

    private static int _day;
    
    // Start is called before the first frame update
    void Awake()
    {
        _day = 1;
    }

    public static int GetDay()
    {
        return _day;
    }

    public static void PassDay()
    {
        _day++;
    }
    
}
