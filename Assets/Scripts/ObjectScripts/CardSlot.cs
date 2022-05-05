using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
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
        if (thisObject.mainSM.isON == true)
        {
            if(tm.currentItem() == "IDCard")
            {
                gm.StartMusic(4);
                this.GetComponent<SpriteRenderer>().sprite = thisObject.change;
                StartCoroutine(tm.typeText(thisObject.clicktext_interactable_true));
                thisObject.mainSM.numPadActivate();
            }
        }
    }
}
