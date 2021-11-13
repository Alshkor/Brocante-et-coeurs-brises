using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerPlayer : MonoBehaviour
{
    public string answer;

    private PNJManagement _pnjManagement;
    // Start is called before the first frame update
    void Start()
    {
        _pnjManagement = GameObject.Find("PNJManager").GetComponent<PNJManagement>();
    }

    public void setText(string ans)
    {
        answer = ans;
        transform.GetChild(0).GetComponent<Text>().text = answer;
    }

    public void NextSentencePNJ()
    {
        _pnjManagement.ChangeSentenceCurrent();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
