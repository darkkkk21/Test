using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollControl : MonoBehaviour
{


    public GameObject HeadPnl,PsyhoPanel;
    
    public Button[] Bttn;



    public void OnClickPanel()
    {

        for (int i = 0; i < Bttn.Length; i++)
        {
            Bttn[i].gameObject.SetActive(false);
        }
        
        if (!PsyhoPanel.gameObject.activeSelf) PsyhoPanel.gameObject.SetActive(true);

        if (!HeadPnl.GetComponent<Animator>().enabled) HeadPnl.GetComponent<Animator>().enabled = true;
        else HeadPnl.GetComponent<Animator>().SetTrigger("In");

    }
    public void OnClickBack()
    {
        
        if (!HeadPnl.GetComponent<Animator>().enabled) HeadPnl.GetComponent<Animator>().enabled = true;
        else HeadPnl.GetComponent<Animator>().SetTrigger("Out");
        StartCoroutine(animH());


    }
    IEnumerator animH()
    {
        yield return new WaitForSeconds(0.7f);

        if (PsyhoPanel.gameObject.activeSelf) PsyhoPanel.gameObject.SetActive(false);

        for (int i = 0; i < Bttn.Length; i++)
        {
            Bttn[i].gameObject.SetActive(true);
        }

        yield break;
    }
}
