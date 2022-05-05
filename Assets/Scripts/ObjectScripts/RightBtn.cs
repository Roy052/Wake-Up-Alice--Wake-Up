using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBtn : MonoBehaviour
{
    public GameObject IDCard;
    GameManager gm;

    private void Start()
    {
        IDCard.SetActive(false);
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        gm.StartMusic(1);
        IDCard.SetActive(true);
    }
}
