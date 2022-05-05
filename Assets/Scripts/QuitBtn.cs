using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitBtn : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnMouseDown()
    {
        gm.StartMusic(1);
        Application.Quit();
    }
}
