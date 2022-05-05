using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public ItemSM itemSM;

    private void OnMouseDown()
    {
        if (itemSM.SelectedItemName() == "Drink")
            itemSM.EAT(0);
        else
            itemSM.EAT(1);
    }
}
