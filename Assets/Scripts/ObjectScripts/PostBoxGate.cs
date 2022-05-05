using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBoxGate : MonoBehaviour
{
    Object thisObject;
    TabManager tm;
    GameManager gm;
    public string[] clicktext;

    public GameObject tongue;
    public GameObject anotherLetter;
    public GameObject letterSize;
    public GameObject drink;
    bool onetime = true;
    bool drinkonetime = false;

    private void Start()
    {
        thisObject = this.gameObject.GetComponent<Object>();
        tm = GameObject.Find("TabManager").GetComponent<TabManager>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        thisObject.anotherText = true;
        tongue.SetActive(false);
        anotherLetter.SetActive(false);
        letterSize.SetActive(false);
        drink.SetActive(false);
    }

    private void Update()
    {
        if (onetime && tm.isItemExist("Letter_1"))
        {
            LetterPickUp();
            onetime = false;
            thisObject.mainSM.numPadActivate();
        }
            
        if(drinkonetime && tm.isItemExist("Drink"))
        {
            DrinkPickUp();
            drinkonetime = false;
        }
    }

    private void OnMouseDown()
    {
        if (thisObject.mainSM.isON == true)
        {
            if (tm.currentItem() == "Letter_0")
            {
                thisObject.interactable = true;
                StartCoroutine(tm.typeText(clicktext[0]));
                tm.ItemDelete(tm.currentItemNum());
                StartCoroutine(throwLetter());
            }
            else StartCoroutine(tm.typeText(clicktext[1]));
        }
    }

    IEnumerator throwLetter()
    {
        thisObject.mainSM.SceneMoveDeactivate();
        gm.StartMusic(6);
        yield return new WaitForSeconds(1);
        tongue.SetActive(true);
        anotherLetter.SetActive(true);
        letterSize.SetActive(true);
        
    }

    void LetterPickUp()
    {
        tongue.SetActive(false);
        thisObject.mainSM.SceneMoveActivate();
    }

    void DrinkPickUp()
    {
        tongue.SetActive(false);
        thisObject.mainSM.SceneMoveActivate();
    }

    public IEnumerator throwDrink()
    {
        thisObject.mainSM.SceneMoveDeactivate();
        gm.StartMusic(6);
        yield return new WaitForSeconds(1);
        tongue.SetActive(true);
        drink.SetActive(true);
        drinkonetime = true;
    }
}
