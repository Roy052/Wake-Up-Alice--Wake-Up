using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postbox : MonoBehaviour
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
        if (thisobject.mainSM.isON == true)
        {
            gm.InToObjectScene(thisobject.objectNum);
        }
    }
}
