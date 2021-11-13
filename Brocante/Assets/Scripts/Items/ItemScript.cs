using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private string _name;
    private bool _sold = false;
    private GameObject _prefab3D;
    private float _price = 100;
    private float _priceSold;

    public Sprite _selection;
    private GameObject selection;
    
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
       
        if (_sold)
        {
           gameObject.SetActive(false); 
        }
        
        _priceSold = _price;
        
         //creation de l'objet et de ses differents composants
        _name = gameObject.name;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/"+gameObject.name);
        _prefab3D = Resources.Load<GameObject>("Prefabs/" + gameObject.name);
        gameObject.AddComponent<BoxCollider2D>();
        
        
        //creation du fond indiquant qu'oin a selectionné l'objet
        selection = new GameObject("Selection");
        selection.transform.SetParent(transform);
        selection.transform.localPosition = new Vector3(0, 0, 2);
        selection.transform.localScale = new Vector3(75, 75, 1);
        selection.AddComponent<SpriteRenderer>().sprite = _selection;
        
        selection.SetActive(false);
        Debug.Log("selection " + _selection.name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        IsItemSelect.SelectAnItem(gameObject);
    }

    public void DisappearSelection()
    {
        selection.SetActive(false);
    }

    public void AppearSelection()
    {
        selection.SetActive(true);
    }

    public void ChangePriceSold(float amount)
    {
        _priceSold += amount;
    }

    public void ChangePrice(float amount)
    {
        _price += amount;
    }
    
    public float GetPriceItemSold()
    {
        return _priceSold;
    }
    public float GetPriceItem()
    {
        return _price;
    }

    public GameObject GetPrefab()
    {
        return _prefab3D;
    }
}
