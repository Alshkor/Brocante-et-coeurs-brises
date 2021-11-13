using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AdaptativeText : MonoBehaviour
{
    [SerializeField] private GameObject _descriptionObject;
    [SerializeField] private GameObject _prixObject;
    [SerializeField] private GameObject _commentaireObject;
    [SerializeField] private GameObject _nameObject;
    // Start is called before the first frame update
    void Start()
    {
        /*On va chercher les GameObject Text qui vont s'adapter*/
        _descriptionObject = GameObject.Find("DescriptionText");
        _commentaireObject = GameObject.Find("CommentaireText");
        _nameObject = GameObject.Find("NameText");
        _prixObject = GameObject.Find("PrixValeur");

        /*
        string jsonFiles = File.ReadAllText(Application.dataPath + "/Resources/testDialogues.json");
        Dialogues dial = new Dialogues();
        dial = JsonUtility.FromJson<Dialogues>(jsonFiles);
        */

        /*
        _descriptionObject.GetComponent<UnityEngine.UI.Text>().text = _description;
        _nameObject.GetComponent<UnityEngine.UI.Text>().text = _name;
        _prixObject.GetComponent<UnityEngine.UI.Text<().test = _prix;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*Classe de listes de descriptions d'objets pour le parsing*/
    public class ListTextObject{
        public List<TextObervationObject> listText;
    }

    /*Classe correspondant à un objet avec son nom, sa description, son prix et ses commentaires*/
    [Serializable]
    public class TextObervationObject{
        /*Nom de l'objet*/
        public string name;
        /*Description de l'objet*/
        public string description;
        /*Liste des réactions possible selon l'endroit qui est appuyé sur l'objet*/
        public List<string> reactionsEvt; 
        /*Prix de vente suggéré*/
        public int prix;
    }
}
