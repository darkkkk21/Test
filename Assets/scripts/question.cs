using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class question : MonoBehaviour
{
    public QuestionList[] questions;

    public Text[] AnswersTxt;
    public Text qtxt;
    public Text infotxt;
    public Text Finishtxt;
   
    public GameObject HeadPnl;
    public Button[] Abttn = new Button[3];
    public Button[] playbttn = new Button[2];
    public Button[] Finishbttn;
    public Button Backbttn;
    private int score, scoreSld;
    
    public Slider sld;
    public Text Sldtext;


    List<object> qList;
    QuestionList crntQ;
    int ranQ;
    


    void Update()
    {
        if (sld.gameObject.activeSelf) { 
            sld.value = scoreSld;
            sld.maxValue = 17;
            Sldtext.text = scoreSld + "/17";
            }
    }
    public void OnClickQuestion()
    {
        if (!infotxt.gameObject.activeSelf) infotxt.gameObject.SetActive(true);
        if (!HeadPnl.gameObject.activeSelf) HeadPnl.gameObject.SetActive(true);
        if (!HeadPnl.GetComponent<Animator>().enabled) HeadPnl.GetComponent<Animator>().enabled = true;
        else HeadPnl.GetComponent<Animator>().SetTrigger("in");
        StartCoroutine(animBttnPlay());


    }
    public void OnClickToBG() 
    {
        StartCoroutine(animBttnPlayBack());

        if (!HeadPnl.GetComponent<Animator>().enabled) HeadPnl.GetComponent<Animator>().enabled = true;
        else HeadPnl.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(animH());
    }
    public void OnClickBack()
    {
        for (int i =0; i < Abttn.Length; i++) Abttn[i].gameObject.SetActive(false);
        if (qtxt.gameObject.activeSelf) qtxt.gameObject.SetActive(false);
        FalsePanel();

    }

    public void OnClickFinishToBG()
    {
        if (!HeadPnl.GetComponent<Animator>().enabled) HeadPnl.GetComponent<Animator>().enabled = true;
        else HeadPnl.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(animH());


    }
    public void FalsePanel()
    {
        if (Finishbttn[0].gameObject.activeSelf) Finishbttn[0].gameObject.SetActive(false);
        if (Finishbttn[1].gameObject.activeSelf) Finishbttn[1].gameObject.SetActive(false);
        if (Finishtxt.gameObject.activeSelf) Finishtxt.gameObject.SetActive(false);
        if (sld.gameObject.activeSelf) sld.gameObject.SetActive(false);
        if (Backbttn.gameObject.activeSelf) Backbttn.gameObject.SetActive(false);
        scoreSld = 0;
        score = 0;
        if (HeadPnl.gameObject.activeSelf) HeadPnl.gameObject.SetActive(false);
        for (int i = 0; i < playbttn.Length; i++) playbttn[i].gameObject.SetActive(false);
        if (infotxt.gameObject.activeSelf) infotxt.gameObject.SetActive(false);
    }
    IEnumerator animH()
    {
        yield return new WaitForSeconds(1);


        FalsePanel();


        yield break;
    }
    public void OnClickPlay()
    {
        if (!sld.gameObject.activeSelf) sld.gameObject.SetActive(true);
        if (!Backbttn.gameObject.activeSelf) Backbttn.gameObject.SetActive(true);
        
        StartCoroutine(animBttnPlayBack());
            
        qList = new List<object>(questions);
            QuestionGen();
        
    }
    public void OnClickPlayAtFinish()
    {
        if (!sld.gameObject.activeSelf) sld.gameObject.SetActive(true);
        if (!Backbttn.gameObject.activeSelf) Backbttn.gameObject.SetActive(true);
        if (Finishbttn[0].gameObject.activeSelf) Finishbttn[0].gameObject.SetActive(false);
        if (Finishbttn[1].gameObject.activeSelf) Finishbttn[1].gameObject.SetActive(false);
        if (Finishtxt.gameObject.activeSelf) Finishtxt.gameObject.SetActive(false);
        scoreSld = 0;
        score = 0;

        qList = new List<object>(questions);
        QuestionGen();

    }
    
    void QuestionGen()
    {
        if (qList.Count > 0)
        {
            ranQ = Random.Range(0, qList.Count);
            crntQ = qList[ranQ] as QuestionList;
            qtxt.text = crntQ.question;
            List<string> answers = new List<string>(crntQ.ansvers);

            for (int i = 0; i < crntQ.ansvers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                AnswersTxt[i].text = answers[rand];
                answers.RemoveAt(rand);
            }
            StartCoroutine(animBttn());
            scoreSld += 1;


        }
        else
        {
            if (!Finishtxt.gameObject.activeSelf) Finishtxt.gameObject.SetActive(true);
            if (!Finishbttn[0].gameObject.activeSelf) Finishbttn[0].gameObject.SetActive(true);
            if (!Finishbttn[1].gameObject.activeSelf) Finishbttn[1].gameObject.SetActive(true);





            if (qtxt.gameObject.activeSelf) qtxt.gameObject.SetActive(false);

            if (score >= 46)
            {
                Finishtxt.text = "В Вас заложен значительный творческий потенциал, который предоставляет Вам богатый выбор творческих возможностей. Если Вы на деле сможете применить Ваши способности, то Вам доступны самые разные формы творчества.";
            }
            if (score >= 22 && score <= 45)
            {
                Finishtxt.text = "У Вас вполне нормальный творческий потенциал. Вы обладаете теми качествами, которые позволяют Вам творить, но у Вас есть и проблемы, тормозящие процесс творчества. Во всяком случае Ваш творческий потенциал позволит Вам творчески себя проявить, если Вы, конечно, этого пожелаете.";
            }
            if (score <= 21 )
            {
                Finishtxt.text = "Ваш творческий потенциал, увы, невелик. Но, может быть, Вы просто недооценили себя? Отсутствие веры в свои силы может привести Вас к мысли, что Вы вообще не способны к творчеству. Избавьтесь от этого и таким образом решите проблему.";
            }
        }

    }

    IEnumerator animBttn()
    {
        if (!qtxt.gameObject.activeSelf) qtxt.gameObject.SetActive(true);
        else qtxt.gameObject.GetComponent<Animator>().SetTrigger("inB");

        yield return new WaitForSeconds(0.6f);
        for (int i = 0 ;i < Abttn.Length; i++) Abttn[i].interactable = false;
        int a = 0;
        while (a < Abttn.Length)
        {
            if (!Abttn[a].gameObject.activeSelf) Abttn[a].gameObject.SetActive(true);
            else Abttn[a].gameObject.GetComponent<Animator>().SetTrigger("inB");
            a++;
            yield return new WaitForSeconds(0.6f);
        }
        for (int i = 0; i < Abttn.Length; i++) Abttn[i].interactable = true;
        yield break;
    }
   
    IEnumerator animBttnPlay()
    {
        if (!infotxt.gameObject.activeSelf) infotxt.gameObject.SetActive(true);
        else infotxt.gameObject.GetComponent<Animator>().SetTrigger("inB");
        yield return new WaitForSeconds(0.6f);
        
        int a = 0;
        while (a < playbttn.Length)
        {
            if (!playbttn[a].gameObject.activeSelf) playbttn[a].gameObject.SetActive(true);
            else playbttn[a].gameObject.GetComponent<Animator>().SetTrigger("inB");
            a++;
            yield return new WaitForSeconds(0.6f);
        }
        
        yield break;
    }
    IEnumerator animBttnPlayBack()
    {
        if (infotxt.gameObject.activeSelf) infotxt.gameObject.GetComponent<Animator>().SetTrigger("inBB");
        else infotxt.gameObject.SetActive(false);

        yield return new WaitForSeconds(0.1f);
        
        int a = 0;
        while (a < playbttn.Length)
        {
            if (playbttn[a].gameObject.activeSelf) playbttn[a].gameObject.GetComponent<Animator>().SetTrigger("inBB");
            else playbttn[a].gameObject.SetActive(false);
            a++;
            yield return new WaitForSeconds(0.1f);
        }
          yield break;
    }
    public void AnswersBttns(int index)
    {
        if (AnswersTxt[index].text.ToString() == crntQ.ansvers[0]) score += 3;
        if (AnswersTxt[index].text.ToString() == crntQ.ansvers[1]) score += 1;
        if (AnswersTxt[index].text.ToString() == crntQ.ansvers[2]) score += 2;
        qList.RemoveAt(ranQ);
        int a = 0;
        while (a < Abttn.Length)
        {
            if (Abttn[a].gameObject.activeSelf) Abttn[a].gameObject.SetActive(false);

            a++;

        }
        QuestionGen();
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] ansvers = new string[3];
}