using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsItemSelect : MonoBehaviour
{
    //TRUE = un item est selectionné, FALSE = pas d'item sélectionné
    private static bool select = false;

    private static GameObject itemSelect;

    public static bool IsItemAlreadySelect()
    {
        return select;
    }

    public static void SelectAnItem(GameObject item)
    {

        if (select)
        {
            itemSelect.GetComponent<ItemScript>().DisappearSelection();
        }

        itemSelect = item;
        itemSelect.GetComponent<ItemScript>().AppearSelection();
        select = true;
    }
    

    public void ChangePriceItemSelected(float amount)
    {
        if (select)
        {
            itemSelect.GetComponent<ItemScript>().ChangePriceSold(amount);
        }

    }

    public static float GetPriceItemSelected()
    {
        if (select)
        {
            return itemSelect.GetComponent<ItemScript>().GetPriceItemSold();
        }

        return -1;

    }
}
