using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumPadBtn : MonoBehaviour
{
    public NumPadManager npm;
    GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnMouseDown()
    {
        gm.StartMusic(1);
        if (this.name == "NumPad_Up") npm.UpBtn();
        else npm.DownBtn();
    }
}
