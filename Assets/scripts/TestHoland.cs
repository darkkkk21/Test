using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestHoland : MonoBehaviour
{
    public TestListHoland[] questions;
    public Text[] AnswersTxt;
    public Text qtxt;
    public Button[] Abttn = new Button[2];
    public Button Abttn1;
    List<object> qList;
    TestListHoland crntQ;
    int ranQ, ran1;
    public int scoreR, scoreI, scoreS, scoreK, scoreP, scoreA;




    public void OnClickPlay()
    {
        //if (!sld.gameObject.activeSelf) sld.gameObject.SetActive(true);
        //if (!Backbttn.gameObject.activeSelf) Backbttn.gameObject.SetActive(true);

       // StartCoroutine(animBttnPlayBack());

        qList = new List<object>(questions);
        QuestionGen();

    }

    public void AnswersBttns(int index)
    {
       
        TestListHoland testQ = qList[0] as TestListHoland;
        string s = testQ.question;

        if (qtxt.text.ToString() == s)
        {
            if (AnswersTxt[index].text.ToString() == crntQ.ansvers[0]) 
            { 
                scoreR += 3;
            }
            

        }
        
        
        
        


        QuestionGen();
    }

    void QuestionGen()
    {
        if (qList.Count > 0)
        {
            ranQ = Random.Range(0, qList.Count);
            crntQ = qList[ranQ] as TestListHoland;
            qtxt.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.ansvers);
            
            for (int i = 0; i < crntQ.ansvers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                AnswersTxt[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
           // StartCoroutine(animBttn());
          //  scoreSld += 1;


        }
        else
        {
           /*if (!Finishtxt.gameObject.activeSelf) Finishtxt.gameObject.SetActive(true);
            if (!Finishbttn[0].gameObject.activeSelf) Finishbttn[0].gameObject.SetActive(true);
            if (!Finishbttn[1].gameObject.activeSelf) Finishbttn[1].gameObject.SetActive(true);
            




            if (qtxt.gameObject.activeSelf) qtxt.gameObject.SetActive(false);

            if (score >= 46)
            {
                Finishtxt.text = "В Вас заложен значительный творческий потенциал, который предоставляет Вам богатый выбор творческих возможностей. Если Вы на деле сможете применить Ваши способности, то Вам доступны самые разные формы творчества.";
            }
            */
        }

    }

}

[System.Serializable]
public class TestListHoland
{
    public string question;
    public string[] ansvers = new string[2];
}
