using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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

    public static List<int> sentenceAlreadySaid;

    private ListDialogues _listDialogues;

    [SerializeField] private PNJManagement _pnjManagement;

    // Start is called before the first frame update
    void Start()
    {
        //Liste des dialogues qui convient à la personne devant nous. Doit être update quand l'on passe à une autre personne ou que
        //l'on fait des actions sur les objets
        _listDialogues = new ListDialogues();

        sentenceAlreadySaid = new List<int>();

        string jsonFiles = File.ReadAllText(Application.dataPath + "/Resources/Discussions/Jour" + NumberDay.GetDay() + "/Player/"+ PNJManagement.GetCurrentPNJ() + ".json");
        
        _listDialogues = JsonUtility.FromJson<ListDialogues>(jsonFiles);
        
        
    }
    


    public void UpdateNumberAnswer()
    {
        //A changer avec une fonction pour calculer le nombre de boite de dialogue disponible
        //numberDialogue = 3;
        GameObject dialogue;
        RectTransform trans;

        List<string> answer;
        int numberDialog = 0;
        try
        {
            numberDialog = _listDialogues.NumberAnswerAvailable(sentenceAlreadySaid, _pnjManagement.GetListSaidPNJ());

            answer = new List<string>();

            answer = _listDialogues.GetAnswer(_pnjManagement.GetListSaidPNJ(), sentenceAlreadySaid);
        }
        catch (Exception e)
        {
            answer = new List<string>();
        }

        numberDialog = Mathf.Clamp(numberDialog, 0, 3);
        
        //Organise les buttons de sélections des dialogues pour que ce soit plus jolie dependant du nombre de dialogues que l'on veut
        switch(numberDialog)
        {
            case 2:
                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[0]);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,75);

                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[1]);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0, -75);
                break;
            case 1:
                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[0]);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,0);
                break;
            case 0:
                dialogue = (Instantiate(_button));
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,0);
                break;
            default:
                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[0]);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,75);

                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[1]);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0,0);
                
                dialogue = Instantiate(_button);
                dialogue.AddComponent<AnswerPlayer>();
                dialogue.GetComponent<AnswerPlayer>().setText(answer[2]);
                trans = dialogue.GetComponent<RectTransform>();
                trans.SetParent(gameObject.transform);
                trans.anchoredPosition = new Vector2(0, -75);
                break;
        }
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

            if (dial.canSay(sentenceSaidByPlayer) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {
                answerAvailable.Add(dial.idSentence);
            }
        }

        if (answerAvailable.Count == 0)
        {
            throw new Exception("Pas d'élément");
        }
        return GetSentenceByID(answerAvailable[0]);
    }
    
    public int NextSentenceID(List<int> sentenceSaidByPlayer, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {
            if (dial.canSay(sentenceSaidByPlayer) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {
                answerAvailable.Add(dial.idSentence);
            }
        }

        if (answerAvailable.Count == 0)
        {
            throw new Exception("Pas d'élément");
        }
        return answerAvailable[0];
    }

    public int NumberAnswerAvailable(List<int> sentenceSaidByPlayer, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {
            if (dial.canSay(sentenceSaidByPlayer) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {
                answerAvailable.Add(dial.idSentence);
            }
        }
        return answerAvailable.Count;
    }

    public string GetSentenceByID(int id)
    {
        foreach (var dial in listDialogues)
        {
            if (dial.idSentence == id)
            {
                return dial.sentence;
            }
        }

        throw new Exception("Pas d'id correspondant");
    }

    public List<String> GetAnswer(List<int> sentenceSaidByPNJ, List<int> sentenceAlreadySaid)
    {
        List<int> answerAvailable = new List<int>();
        foreach (var dial in listDialogues)
        {
            
            if (dial.canSay(sentenceSaidByPNJ) && !sentenceAlreadySaid.Contains(dial.idSentence))
            {

                
                answerAvailable.Add(dial.idSentence);
            }
        }

        if (answerAvailable.Count == 0)
        {
            throw new Exception("Pas d'élément");
        }

        List<string> returnAnswer = new List<string>();
        
        for(int i = 0; i < 3 ;i ++)
        {
            returnAnswer.Add(GetSentenceByID(answerAvailable[i]));
        }
        return returnAnswer;
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
    public List<int> canSayIf;

    public bool canSay(List<int> sentenceByPlayer)
    {
        if (canSayIf.Count == 0)
        {
            return true;
        }
        foreach (int sent in sentenceByPlayer)
        {
            if (canSayIf.Contains(sent))
            {
                return true;
            }
        }

        return false;
    }

}
