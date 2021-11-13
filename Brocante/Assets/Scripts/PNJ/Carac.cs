using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carac : MonoBehaviour
{
    //On y stock tous les ID des phrases dites par le PNJ actuel
    private List<int> _sentenceSaid;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _sentenceSaid = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


//Class qui contient les propriétés du PNJ qui fait face au joueur. Doit notamment contenir les paramètres contenus dans le JSon qui décrits les personnage.

public class PNJ
{
    //Nom du personnage
    private string name;
    
    //Son niveau de richesse
    private float richness;

}

//class qui répértorie les phrases qui se déclenchent aprés une action spéciale
public class EventSentence
{
    //Déclenche la phrase lorsque l'on effectue une action sur l'objet représenté par idObject.
    private int idObject;
    
    //La phrase que doit dire le personnage.
    private string sentence;
}