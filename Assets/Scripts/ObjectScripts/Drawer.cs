using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{
    Object thisobject;
    GameManager gm;

    private void Start()
    {
        thisobject = this.gameObject.GetComponent<Object>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if(thisobject.mainSM.isON == true)
        {
            if (thisobject.isActivated == true)
            {
                
                gm.InToObjectScene(thisobject.objectNum);
            }
            else
            {
                gm.StartMusic(2);
                thisobject.isActivated = true;
            }
        }
    }
}
