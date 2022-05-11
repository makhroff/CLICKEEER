using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Item
{
    hamsterWheel,
    solarPanel,
    wind,
    water,
    bioenergy,
    geothermal
}
public class ShopItem : MonoBehaviour
{
    public ulong itemPrice;
    [SerializeField] private ulong requirementToUnlockItem;
    [SerializeField] private GameObject lockItem;
    [SerializeField] private Text itemCount;
    public Text itemPriceText;
    private Button button;

    public ulong priceMultiplier = 1ul;

    public Item item;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.enabled = false;

    }
    private void Update()
    {
        UnlockItem();
    }

    private void UnlockItem()
    {
        switch (item)
        {
            case Item.hamsterWheel:
                lockItem.SetActive(false);
                button.enabled = true;
                break;
            case Item.solarPanel:
                if(EnergyManager.instance.saveData.hamsterWheel >= requirementToUnlockItem)
                    lockItem.SetActive(false);
                button.enabled = true;
                break;
            case Item.wind:
                if (EnergyManager.instance.saveData.solarPanels >= requirementToUnlockItem)
                    lockItem.SetActive(false);
                button.enabled = true;
                break;
            case Item.water:
                if (EnergyManager.instance.saveData.wind >= requirementToUnlockItem)
                    lockItem.SetActive(false);
                button.enabled = true;
                break;
            case Item.bioenergy:
                if (EnergyManager.instance.saveData.water >= requirementToUnlockItem)
                    lockItem.SetActive(false);
                button.enabled = true;
                break;
            case Item.geothermal:
                if (EnergyManager.instance.saveData.bioenergy >= requirementToUnlockItem)
                    lockItem.SetActive(false);
                button.enabled = true;
                break;
        }
    }
    public void BuyThisItem()
    {
        if(EnergyManager.instance.saveData.totalEnergy >= itemPrice * priceMultiplier)
        {
            EnergyManager.instance.saveData.totalEnergy -= itemPrice * priceMultiplier;

            switch (item)
            {
                case Item.hamsterWheel:
                    EnergyManager.instance.saveData.hamsterWheel += priceMultiplier;
                    itemCount.text = EnergyManager.instance.saveData.hamsterWheel.ToString();
                    break;

                case Item.solarPanel:
                    EnergyManager.instance.saveData.solarPanels += priceMultiplier;
                    itemCount.text = EnergyManager.instance.saveData.solarPanels.ToString();
                    break;

                case Item.wind:
                    EnergyManager.instance.saveData.wind += priceMultiplier;
                    itemCount.text = EnergyManager.instance.saveData.wind.ToString();
                    break;

                case Item.water:
                    EnergyManager.instance.saveData.water += priceMultiplier;
                    itemCount.text = EnergyManager.instance.saveData.water.ToString();
                    break;

                case Item.bioenergy:
                    EnergyManager.instance.saveData.bioenergy += priceMultiplier;
                    itemCount.text = EnergyManager.instance.saveData.bioenergy.ToString();
                    break;

                case Item.geothermal:
                    EnergyManager.instance.saveData.geothermal += priceMultiplier;
                    itemCount.text = EnergyManager.instance.saveData.geothermal.ToString();
                    break;
            }
        }
    }
}
