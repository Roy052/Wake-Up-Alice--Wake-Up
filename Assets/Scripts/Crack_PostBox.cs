using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack_PostBox : MonoBehaviour
{
    MainSM mainSM;
    bool onetime = true;
    public GameObject postBoxGate;

    private void Start()
    {
        mainSM = this.gameObject.GetComponent<MainSM>();
    }

    private void Update()
    {
        if (onetime == true && mainSM.isON == true && mainSM.numpadObjects != null)
        {
            if (mainSM.numpadObjects[0].GetComponent<NumPadManager>().value == 3 &&
                mainSM.numpadObjects[1].GetComponent<NumPadManager>().value == 2)
            {
                onetime = false;
                StartCoroutine(postBoxGate.GetComponent<PostBoxGate>().throwDrink());
            }
        }
    }
}
