using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongBtn : MonoBehaviour
{
    public MainSM mainSM;
    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        gm.StartMusic(1);
        if (mainSM.isON == true) gm.GameOver(0);

    }
}
