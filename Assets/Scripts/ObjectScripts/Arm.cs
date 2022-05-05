using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm : MonoBehaviour
{
    int value = 12;
    bool armSet = false;
    float setTime;
    TabManager tm;
    int times = 0;
    Object thisObject;
    bool onetime = true;
    GameManager gm;

    private void Start()
    {
        tm = GameObject.Find("TabManager").GetComponent<TabManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisObject = this.gameObject.GetComponent<Object>();
        thisObject.anotherText = true;
    }

    private void FixedUpdate()
    {

        if (thisObject.mainSM.isON == true)
        {
            setTime += Time.fixedDeltaTime;
        }
        else
            setTime = 0;

        if (armSet == false && setTime >= 2 && value == 1)
        {
            tm.openTime = true;
            armSet = true;
            gm.StartMusic(5);
        }
            
            
    }

    private void OnMouseDown()
    {
        if (onetime == true)
        {
            onetime = false;
            StartCoroutine(tm.typeText("It sounds weird"));
        }
        if (armSet == false) {
            gm.Scream();
            setTime = 0;
            value = (value % 12) + 1;
            times = (times + 1) % 12;
            this.transform.rotation = Quaternion.AngleAxis(-30 * times ,new Vector3(0,0,1));
            
        }
    }
}
