using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class CreateDialogues : MonoBehaviour
{
    //Nombres de boite de dialogue sélectionnable
    [SerializeField]private  int numberDialogue = 3;

    [SerializeField] private GameObject _button;

    private List<DialoguesPNJ> _dialogues;

    // Start is called before the first frame update
    void Start()
    {
        //A changer avec une fonction pour calculer le nombre de boite de dialogue disponible
        //numberDialogue = 3;
        GameObject dialogue;
        RectTransform trans;
        
        //Organise les buttons de sélections des dialogues pour que ce soit plus jolie dependant du nombre de dialogues que l'on veut
        switch(numberDialogue)
        {
            case 3:
                dialogue = Instantiate(_button);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,75);

                dialogue = Instantiate(_button);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,0);
                
                dialogue = Instantiate(_button);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0, -75);
                break;
            case 2:
                dialogue = Instantiate(_button);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,75);

                dialogue = Instantiate(_button);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0, -75);
                break;
            case 1:
                dialogue = Instantiate(_button);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,0);
                break;
        }

        //Liste des dialogues qui convient à la personne devant nous. Doit être update quand l'on passe à une autre personne ou que
        //l'on fait des actions sur les objets
        ListDialogues _listDialogues = new ListDialogues();

        string jsonFiles = File.ReadAllText(Application.dataPath + "/Resources/testDialogues.json");


        Debug.Log("json : " + jsonFiles);
        //EditorJsonUtility.FromJsonOverwrite(jsonFiles, boxDial);
        _listDialogues = JsonUtility.FromJson<ListDialogues>(jsonFiles);

        foreach (var truc in _listDialogues.listDialogues)
        {
            Debug.Log("un truc " + truc.sentence);
        }


        //Debug.Log("List des dialogujes " + _listDialogues.listDialogues.Count);
        
        //dial = _listDialogues.listDialogues[0];
        
        //Debug.Log("est ce que dial est bien ? " + dial.sentence);
        //_dialogues.Add(dial);

        //Debug.Log("dialogues : " + _dialogues[0].sentence);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class ListDialogues
{
    public List<DialoguesPNJ> listDialogues;

    public string NextSentence(List<int> sentenceSaidByPlayer, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {
            foreach (int sentencePlayerID in sentenceSaidByPlayer)
            {
                
            }
        }

        return "bou";
    }
}

[Serializable]
public class DialoguesPNJ
{
    //Phrase du dialogue
    public string sentence;
    
    //Int représentant ce que va répondre le PNJ (pour pouvoir "retrouver" ce qu'a dit le joueur et adapter la réponse du pnj)
    public int idSentence;
    
    //Bool pour savoir si la phrase est bloqué ou pas
    public List<int> canSayif;

}
