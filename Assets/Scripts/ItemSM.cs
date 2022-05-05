using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSM : MonoBehaviour
{
    GameManager gm;
    TabManager tm;
    GameObject grayScreen, X;
    public GameObject[] items;
    int selected = 0;
    GameObject itemLight;
    GameObject eatButton;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        tm = GameObject.Find("TabManager").GetComponent<TabManager>();

        grayScreen = GameObject.Find("GrayScreen");
        X = GameObject.Find("X");
        itemLight = GameObject.Find("ItemLight");
        eatButton = GameObject.Find("Eat_Button");

        itemLight.SetActive(false);
        grayScreen.SetActive(false);
        X.SetActive(false);
        if (items != null)
            for (int i = 0; i < items.Length; i++)
                items[i].SetActive(false);
        eatButton.SetActive(false);
    }

    public void ONthisScene(string itemName)
    {
        grayScreen.SetActive(true);
        X.SetActive(true);
        itemLight.SetActive(true);
        if (items != null)
            for (int i = 0; i < items.Length; i++)
                if (items[i].name == itemName)
                {
                    items[i].SetActive(true);
                    selected = i;
                    if (itemName == "Drink" || itemName == "Cake")
                        eatButton.SetActive(true);
                    break;
                }       
    }
    public void OFFthisScene()
    {
        grayScreen.SetActive(false);
        items[selected].SetActive(false);
        X.SetActive(false);
        itemLight.SetActive(false);
        eatButton.SetActive(false);
    }

    public string SelectedItemName()
    {
        return items[selected].name;
    }

    public void EAT(int num) //0 : drink, 1 : cake
    {
        if (num == 0 && tm.openTime == false)
            gm.GameOver(2);
        else if (num == 1)
            gm.GameOver(1);
        else
            tm.eatSmall = true;
    }
}
