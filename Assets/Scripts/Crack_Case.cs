using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crack_Case : MonoBehaviour
{
    MainSM mainSM;
    bool onetime = true;
    public bool letteronetime = false;
    public Sprite backgroundChange;
    public GameObject intheCase;
    TabManager tm;
    public bool caseOpenBool = false;
    public bool onetimeforcase = false;

    private void Start()
    {
        mainSM = this.gameObject.GetComponent<MainSM>();
        intheCase.SetActive(false);
        tm = GameObject.Find("TabManager").GetComponent<TabManager>();
    }

    private void Update()
    {
        if (onetimeforcase == true && mainSM.isON == true && caseOpenBool == true)
        {
            ONthisScene();
            onetimeforcase = false;
        }

        if (mainSM.isON == false && caseOpenBool == true)
            onetimeforcase = true;

        if(onetime == true && mainSM.isON == true && mainSM.numpadObjects != null)
        {
            if(mainSM.numpadObjects[0].GetComponent<NumPadManager>().value == 1 &&
                mainSM.numpadObjects[1].GetComponent<NumPadManager>().value == 8 &&
                mainSM.numpadObjects[2].GetComponent<NumPadManager>().value == 1 &&
                mainSM.numpadObjects[3].GetComponent<NumPadManager>().value == 3)
            {
                onetime = false;
                StartCoroutine(CaseOpen());
            }
        }

        if (letteronetime == true && tm.isItemExist("Letter_0"))
        {
            letteronetime = false;
            LetterPickUp();
        }
           
    }

    IEnumerator CaseOpen()
    {
        mainSM.SceneMoveDeactivate();
        yield return new WaitForSeconds(1);
        mainSM.OFFthisScene();
        mainSM.isON = true;
        mainSM.background.GetComponent<SpriteRenderer>().sprite = backgroundChange;
        mainSM.background.SetActive(true);
        intheCase.SetActive(true);
        letteronetime = true;
        caseOpenBool = true;
    }

    public void ONthisScene()
    {
        mainSM.OFFthisScene();
        mainSM.isON = true;
        mainSM.sceneMoveButtons[0].SetActive(true);
        mainSM.background.GetComponent<SpriteRenderer>().sprite = backgroundChange;
        mainSM.background.SetActive(true);
    }

    void LetterPickUp()
    {
        mainSM.SceneMoveActivate();
    }
}
