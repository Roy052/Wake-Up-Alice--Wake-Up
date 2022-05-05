using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumPadManager : MonoBehaviour
{
    public GameObject up, down, numpad, numpadNum;
    public int value = 0;
    public bool isON;
    public Sprite[] numpadNums;

    private void Start()
    {
        value = 0;
        numpadNum.GetComponent<SpriteRenderer>().sprite = numpadNums[value];
        isON = false;
    }
    public void ONthisScene()
    {
        up.SetActive(true);
        down.SetActive(true);
        numpad.SetActive(true);
        numpadNum.SetActive(true);
    }

    public void OFFthisScene()
    {
        up.SetActive(false);
        down.SetActive(false);
        numpad.SetActive(false);
        numpadNum.SetActive(false);
    }

    public void UpBtn()
    {
        if (isON)
        {
            value = (value + 1) % 10;
            numpadNum.GetComponent<SpriteRenderer>().sprite = numpadNums[value];
        }
    }

    public void DownBtn()
    {
        if (isON)
        {
            if (value == 0) value = 9;
            else value -= 1;
            numpadNum.GetComponent<SpriteRenderer>().sprite = numpadNums[value];
        }
    }
}
