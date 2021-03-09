using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestJe : MonoBehaviour
{
    public TestListJe[] questions;

    public Text[] AnswersTxt;
    public Text qtxt;
    public Text infotxt;
    public Text Finishtxt;

    public GameObject HeadPnl;
    public Button[] Abttn = new Button[4];
    public Button[] playbttn = new Button[2];
    public Button[] Finishbttn;
    public Button Backbttn;
    public int scoreA, scoreSld, scoreB, scoreC, scoreD;

    public Slider sld;
    public Text Sldtext;


    List<object> qList;
    TestListJe crntQ;
    int ranQ;



    void Update()
    {
        if (sld.gameObject.activeSelf)
        {
            sld.value = scoreSld;
            sld.maxValue = 6;
            Sldtext.text = scoreSld + "/6";
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
        scoreA = 0;
        scoreB = 0;
        scoreC = 0;
        scoreD = 0;
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
        scoreA = 0;
        scoreB = 0;
        scoreC = 0;
        scoreD = 0;
        
        qList = new List<object>(questions);
        QuestionGen();

    }

    void QuestionGen()
    {
        if (qList.Count > 0)
        {
            ranQ = Random.Range(0, qList.Count);
            crntQ = qList[ranQ] as TestListJe;
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


            if (scoreA >= scoreB && scoreA >= scoreC && scoreA >= scoreD)
            {
                Finishtxt.text = "ты волевой и целеустремленный человек, который привык идти к цели напролом. Не забывай, что одна только сила не всегда помогает достичь нужного результата. Применяй хитрость, находчивость, а иногда и слабость, и тогда ты поймешь, что добиться желаемого станет гораздо легче!";
            }

            if (scoreB >= scoreA && scoreB >= scoreC && scoreB >= scoreD)
            {
                Finishtxt.text = "ты дружелюбный и открытый человек, но хватает ли тебе независимости? Способен ли ты не поддаваться чужому влиянию? Тебе не помешает научиться расставлять приоритеты и распределять свою энергию так, чтобы не чувствовать себя измотанным. Тогда ты не только быстро поймешь, что именно тебе нужно, но и как этого достичь. А окружающие, оценив твои порывы, станут чаще помогать тебе.";
            }
            if (scoreC >= scoreB && scoreC >= scoreA && scoreC >= scoreD)
            {
                Finishtxt.text = "ты склонен подходить к делу креативно. Тебе нравится выдумывать и изобретать, сочинять и фантазировать! Это здорово, но не забывай о том, что иногда самый простой путь оказывается самым коротким! Не создавай излишних сложностей, но в то же время не стесняйся воплощать свои мечты в жизнь. Они того стоят!";
            }

            if (scoreD >= scoreB && scoreD >= scoreC && scoreD >= scoreA)
            {
                Finishtxt.text = "тебя можно назвать уверенным в себе человеком, осознающим свои достоинства и умеющего распорядиться ими. Однако иногда недостаточно просто привлекать внимание. Подумай о том, как ты можешь развивать отношения или беседу, прислушивайся к мнениям других, учись понимать эмоции и настроение собеседника. Взаимодействуя с другими, ты сможешь добиться большего!";
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
        if (AnswersTxt[index].text.ToString() == crntQ.ansvers[0]) scoreA += 1;
        if (AnswersTxt[index].text.ToString() == crntQ.ansvers[1]) scoreB += 1;
        if (AnswersTxt[index].text.ToString() == crntQ.ansvers[2]) scoreC += 1;
        if (AnswersTxt[index].text.ToString() == crntQ.ansvers[3]) scoreD += 1;
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
public class TestListJe
{
    public string question;
    public string[] ansvers = new string[4];
}

