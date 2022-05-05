using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSM : MonoBehaviour
{
    public GameObject screen, background;
    public GameObject[] items;
    public GameObject[] objects;
    public GameObject[] sceneMoveButtons;
    public GameObject[] numpadObjects;

    public bool isON = false;
    public bool isLoaded = false;

    public string startText;
    TabManager tm;

    public string sceneName;

    private void Start()
    {
        tm = GameObject.Find("TabManager").GetComponent<TabManager>();
        StartCoroutine(tm.typeText(startText));
        OFFthisScene();
        isLoaded = true;
    }

    public void ONthisScene()
    {
        isON = true;
        Debug.Log("ONthisScene" + this.gameObject.name);
        screen.SetActive(true);
        background.SetActive(true);

        if(items != null)
            for (int i = 0; i < items.Length; i++)
                items[i].SetActive(true);
                

        if (objects != null)
            for (int i = 0; i < objects.Length; i++)
                objects[i].SetActive(true);

        if (sceneMoveButtons != null)
            for (int i = 0; i < sceneMoveButtons.Length; i++)
                sceneMoveButtons[i].SetActive(true);
                

        if (numpadObjects != null)
            for (int i = 0; i < numpadObjects.Length; i++)
                numpadObjects[i].GetComponent<NumPadManager>().ONthisScene();
    }

    public void OFFthisScene()
    {
        isON = false;
        screen.SetActive(false);
        background.SetActive(false);

        if (items != null)
            for (int i = 0; i < items.Length; i++)
                if(items[i].GetComponent<Item>().inTab == false) 
                    items[i].SetActive(false);

        if (objects != null)
            for (int i = 0; i < objects.Length; i++)
                objects[i].SetActive(false);

        if (sceneMoveButtons != null)
            for (int i = 0; i < sceneMoveButtons.Length; i++)
                sceneMoveButtons[i].SetActive(false);

        if (numpadObjects != null)
            for (int i = 0; i < numpadObjects.Length; i++)
                numpadObjects[i].GetComponent<NumPadManager>().OFFthisScene();
    }

    public void numPadActivate()
    {
        if (numpadObjects != null)
            for (int i = 0; i < numpadObjects.Length; i++)
                numpadObjects[i].GetComponent<NumPadManager>().isON = true;

    }

    public void SceneMoveActivate()
    {
        if (sceneMoveButtons != null)
            for (int i = 0; i < sceneMoveButtons.Length; i++)
                sceneMoveButtons[i].SetActive(true);
    }
    public void SceneMoveDeactivate()
    {
        if (sceneMoveButtons != null)
            for (int i = 0; i < sceneMoveButtons.Length; i++)
                sceneMoveButtons[i].SetActive(false);
    }

    public bool LoadCheck()
    {
        bool check = true;
        if (screen == null) check = false;
        if (background == null) check = false;
        if (objects == null) check = false;
        if (sceneMoveButtons == null) check = false;

        return check;
    }
}
