using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Carac : MonoBehaviour
{
    //On y stock tous les ID des phrases dites par le PNJ actuel
    public List<int> _sentenceSaid;
    
    //Nom de la personne qui parle (tous les fichiers lui étant attribué doivent être à ce nom)
    [SerializeField] private string _name;

    [SerializeField] private CreateDialogues _playerDialogues;

    //Liste des dialogues du personnage le jour qui va bien
    private ListDialogues _listeDialogues;
    
    // Start is called before the first frame update
    void Start()
    {
        _sentenceSaid = new List<int>();
        
        _listeDialogues = new ListDialogues();

        string jsonFiles = File.ReadAllText(Application.dataPath + "/Resources/Discussions/Jour" + NumberDay.GetDay() + "/PNJ/"+ _name + ".json");
        
        _listeDialogues = JsonUtility.FromJson<ListDialogues>(jsonFiles);

    }
    
    private string Speak()
    {
        var sentence = _listeDialogues.NextSentence(CreateDialogues.sentenceAlreadySaid, _sentenceSaid);
        _sentenceSaid.Add(_listeDialogues.NextSentenceID(CreateDialogues.sentenceAlreadySaid, _sentenceSaid));

        return sentence;
    }

    public void changeText()
    {
        _playerDialogues.UpdateNumberAnswer();
        TextPersonnage.UpdateSentence(Speak());
        
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