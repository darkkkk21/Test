using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollMenu : MonoBehaviour
{
    public GameObject panelScroll;
    public Button[] Bttn;
    private Vector3 screenPoint, offset;
    private float _lickedYPos;
    private bool move;

    void Update()
    {
        if (panelScroll.transform.position.y > 0f)
           panelScroll.transform.position = Vector3.MoveTowards(panelScroll.transform.position, new Vector3(panelScroll.transform.position.x, 0f, panelScroll.transform.position.z), Time.deltaTime * 12f);
        else if(panelScroll.transform.position.y < -4.2f)
            panelScroll.transform.position = Vector3.MoveTowards(panelScroll.transform.position, new Vector3(panelScroll.transform.position.x, -4.2f, panelScroll.transform.position.z), Time.deltaTime * 12f);
       
    }


    void OnMouseDown() {
       
        _lickedYPos = screenPoint.y;
        offset = panelScroll.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        Cursor.visible = false;
        
            
        


    }

    void OnMouseDrag() {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.x = _lickedYPos;
        panelScroll.transform.position = curPosition;
       
        

    }
    void OnMouseUp()
    {
       
        Cursor.visible = true;

        
    }

   public void OnClickScroll(bool isMove)
    {
        move = isMove;
    }
}
