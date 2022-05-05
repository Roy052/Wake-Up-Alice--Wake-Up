using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialItem : MonoBehaviour
{
    MainSM mainSM;

    private void Start()
    {
        mainSM = this.gameObject.GetComponent<Item>().mainSM;
    }

    private void FixedUpdate()
    {
        if (mainSM.isON == true)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }
}
