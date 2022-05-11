using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct SaveData
{
    public ulong totalEnergy;

    //---DEPARTMENTS---\\
    [Space] [Header("DEPARTMENTS")]
    public bool cleanEnergyDepartment;

    //---Generators---\\
    [Space] [Header("GENERATORS")]
    public ulong hamsterWheel;
    public ulong solarPanels;
    public ulong wind;
    public ulong water;
    public ulong bioenergy;
    public ulong geothermal;

    //---BONUSES---\\
    [Space] [Header("BONUSES")]
    public byte clicMultiplier;
}

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager instance;

    public SaveData saveData;
    [SerializeField] private Text energyCounter;

    private void Awake()
    {
        instance = this;

        saveData = SaveManager.LoadData();
        SaveManager.Save(saveData);
        
        StartAllGenerators();
    }
    private void Update()
    {
        energyCounter.text = saveData.totalEnergy.ToString();
    }

    public void StartAllGenerators()
    {
        InvokeRepeating("HamsterWheel", 0f, 1f);
        InvokeRepeating("SolarPanels", 0f, 1f / 10f);
        InvokeRepeating("Wind", 0f, 1f / 100f);
        InvokeRepeating("Water", 0f, 1f / 100f);
        InvokeRepeating("Bioenergy", 0f, 1f / 100f);
        InvokeRepeating("Geothermal", 0f, 1f / 100f);
    }
    private void HamsterWheel()
    {
        if (saveData.hamsterWheel != 0)
            saveData.totalEnergy += (saveData.hamsterWheel * 1);
    }
    private void SolarPanels()
    {
        if (saveData.solarPanels != 0)
            saveData.totalEnergy += (saveData.solarPanels * 1);
    }
    private void Wind()
    {
        if (saveData.wind != 0)
            saveData.totalEnergy += (saveData.wind * 2 * 1);
    }
    private void Water()
    {
        if (saveData.water != 0)
            saveData.totalEnergy += (saveData.water * 100 * 1);
    }
    private void Bioenergy()
    {
        if (saveData.bioenergy != 0)
            saveData.totalEnergy += (saveData.bioenergy * 10_000 * 1);
    }
    private void Geothermal()
    {
        if (saveData.geothermal != 0)
            saveData.totalEnergy += (saveData.geothermal * 10_000_000 * 1);
    }


    public void AddEnergy(ulong energyToAdd)
    {
        saveData.totalEnergy += energyToAdd;
    }

    private void OnApplicationQuit()
    {
        SaveManager.Save(saveData);
    }
}
