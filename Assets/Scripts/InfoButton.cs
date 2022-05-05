using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    TabManager tabManager;

    private void Start()
    {
        tabManager = GameObject.Find("TabManager").GetComponent<TabManager>();
    }
    private void OnMouseDown()
    {
        tabManager.InfoButtonPushed();
    }
}
