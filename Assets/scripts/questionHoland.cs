using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questionHoland : MonoBehaviour
{
    public QuestionListHoland[] questions;

    public Text[] AnswersTxt;
    public Text qtxt;
    public Text infotxt;
    public Text Finishtxt;

    public GameObject HeadPnl;
    public Button[] Abttn = new Button[2];
    public Button[] playbttn = new Button[2];
    public Button[] Finishbttn;
    public Button Backbttn;
    public int score, scoreSld;

    public Slider sld;
    public Text Sldtext;


    List<object> qList;
    QuestionListHoland crntQ;
    int ranQ;



    void Update()
    {
        if (sld.gameObject.activeSelf)
        {
            sld.value = scoreSld;
            sld.maxValue = 25;
            Sldtext.text = scoreSld + "/25";
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
        for (int i = 0; i < Abttn.Length; i++) Abttn[i].gameObject.SetActive(false);
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
            crntQ = qList[ranQ] as QuestionListHoland;
            qtxt.text = crntQ.questionHoland;
            List<string> ansversHol = new List<string>(crntQ.ansversHol);
            for (int i = 0; i < crntQ.ansversHol.Length; i++)
            {
                
                AnswersTxt[i].text = ansversHol[i];
               
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

            if (score >= 72)
            {
                Finishtxt.text = "Вы плохой собеседник. Вам необходимо работать над собой и учиться слушать.";
            }
            if (score >= 40 && score <= 71)
            {
                Finishtxt.text = "Вам присущи некоторые недостатки. Вы критически относитесь к высказываниям, Вам еще недостает некоторых достоинств хорошего собеседника, избегайте поспешных выводов, не заостряйте внимание на манере говорить, не притворяйтесь, ищите скрытый смысл сказанного, не монополизируйте разговор.";
            }
            if (score >= 12 && score <= 39)
            {
                Finishtxt.text = "Вы хороший собеседник, но иногда отказываете партнеру в полном внимании. Повторяйте вежливо его высказывания, дайте ему время раскрыть свою мысль полностью, приспосабливайте свой темп мышления к его речи и можете быть уверены, что общаться с Вами будет еще приятнее; ";
            }
            if (score <= 11)
            {
                Finishtxt.text = "Вы отличный собеседник. Вы умеете слушать, Ваш стиль общения может стать примером для окружающих.";
            }

        }
    }
        IEnumerator animBttn()
        {
            if (!qtxt.gameObject.activeSelf) qtxt.gameObject.SetActive(true);
            else qtxt.gameObject.GetComponent<Animator>().SetTrigger("inB");

            yield return new WaitForSeconds(0.6f);
            for (int i = 0; i < Abttn.Length; i++) Abttn[i].interactable = false;
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
            if (AnswersTxt[index].text.ToString() == crntQ.ansversHol[0]) score += 4;
            if (AnswersTxt[index].text.ToString() == crntQ.ansversHol[1]) score += 0;

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
public class QuestionListHoland
{
    public string questionHoland;
    public string[] ansversHol = new string[2];
}
