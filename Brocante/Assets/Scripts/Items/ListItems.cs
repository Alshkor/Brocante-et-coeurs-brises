using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ListItems : MonoBehaviour
{
    private List<GameObject> _items;
    [SerializeField] private Sprite bg;
    
    // Start is called before the first frame update
    void Start()
    {
        _items = new List<GameObject>();
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            _items.Add(transform.GetChild(i).gameObject);
        }
        
        
        ListItemsJSon _listItems = new ListItemsJSon();

        string jsonFiles = File.ReadAllText(Application.dataPath + "/Resources/Items.json");
        
        _listItems = JsonUtility.FromJson<ListItemsJSon>(jsonFiles);
        Debug.Log("On passe bien ici");
        int j = 0;
        foreach (var truc in _listItems.itemsList)
        {

            Debug.Log("un truc " + truc.name);
            GameObject item = _items[j];
            item.name = truc.name;
            item.AddComponent<SpriteRenderer>();
            item.AddComponent<ItemScript>();
            item.GetComponent<ItemScript>()._selection = bg;
            j++;
        }
        
        
    }
    
}

public class ListItemsJSon
{
    public List<Items> itemsList;
}

[Serializable]
public class Items
{
    //Sprite de l'objet
    public Sprite _sprite;
    
    //Prefab de l'objet pour la visualisation 3D
    public GameObject _prefab;

    public float _prix;

    public string name;
}
