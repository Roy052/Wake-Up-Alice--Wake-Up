using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Object thisObject;
    TabManager tm;
    public string[] clicktext;
    GameManager gm;

    private void Start()
    {
        thisObject = this.gameObject.GetComponent<Object>();
        tm = GameObject.Find("TabManager").GetComponent<TabManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisObject.anotherText = true;
    }
    private void OnMouseDown()
    {
        if (thisObject.isActivated == true)
            gm.MainToMidScene();

        if (thisObject.mainSM.isON == true)
        {
            if (tm.currentItem() == "Key_0")
            {
                if (tm.isItemExist("Lantern"))
                {
                    gm.StartMusic(3);
                    thisObject.interactable = true;
                    thisObject.isActivated = true;
                    StartCoroutine(tm.typeText(clicktext[0]));
                }
                else
                {
                    StartCoroutine(tm.typeText(clicktext[1]));
                }
            }
            else if(thisObject.interactable == true) StartCoroutine(tm.typeText(clicktext[0]));
            else StartCoroutine(tm.typeText(clicktext[2]));
        }
        
            
    }
}
