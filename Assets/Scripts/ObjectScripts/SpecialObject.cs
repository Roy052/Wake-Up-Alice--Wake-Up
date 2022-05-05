using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialObject : MonoBehaviour
{
    public MainSM mainSM;
    private void FixedUpdate()
    {
        if (mainSM.isON == true)
            this.gameObject.SetActive(true);
        else
            this.gameObject.SetActive(false);
    }
}
