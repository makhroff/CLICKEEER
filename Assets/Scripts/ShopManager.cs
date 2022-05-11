using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject baseDepartment;
    [SerializeField] private GameObject cleanEnvironmentDepartment;
    [SerializeField] private List<ShopItem> shopItems;
    
    private bool isCEActive;


    public void ActiveShopPanel()
    {
        shopPanel.SetActive(!shopPanel.activeSelf);
    }
    public void ActiveCleanEnvironmentPanel()
    {
        cleanEnvironmentDepartment.SetActive(true);
        baseDepartment.SetActive(false);
        isCEActive = true;
    }
    public void ActiveBasePanel()
    {
        if(isCEActive)
        {
            baseDepartment.SetActive(true);
            cleanEnvironmentDepartment.SetActive(false);
            isCEActive = false;
        }
        else
        {
            ActiveShopPanel();
        }
    }
    
    public void SetPriceMultiplier(int multyplier)
    {
        foreach(ShopItem item in shopItems)
        {
            item.priceMultiplier = (ulong)multyplier;
            item.itemPriceText.text = $"PRICE: {item.itemPrice * item.priceMultiplier}";
        }
    } 
}
