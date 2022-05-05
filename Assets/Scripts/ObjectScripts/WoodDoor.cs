using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodDoor : MonoBehaviour
{
    Object thisObject;
    TabManager tm;
    GameManager gm;
    public string[] clicktext;

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
            gm.GameClear(0);

        if (thisObject.mainSM.isON == true)
        {
            if (tm.openTime == true)
            {
                if (tm.eatSmall == true)
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
            else StartCoroutine(tm.typeText(clicktext[2]));
        }
    }
}
