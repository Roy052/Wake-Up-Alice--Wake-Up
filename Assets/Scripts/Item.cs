using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    TabManager tabManager;
    public MainSM mainSM;
    public bool inTab = false;
    int buttonNum = -1;
    public string itemDescription;

    private void Start()
    {
        tabManager = GameObject.Find("TabManager").GetComponent<TabManager>();
    }
    private void OnMouseDown()
    {
        if(mainSM.isON == true || inTab)
        {
            if (inTab == false)
            {
                buttonNum = tabManager.ItemAdded(this.name);
                inTab = true;
                tabManager.StartMusic(8);
                if (this.name == "Lantern") tabManager.FoundLight();
            }
            else
            {
                tabManager.inTabItemPushed(buttonNum);
            }
        }
    }
}
