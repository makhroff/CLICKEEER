using System;
using UnityEngine;

[Serializable]
public struct SaveData
{
    public ulong totalEnergy;

    //---DEPARTMENTS---\\
    [Space] [Header("DEPARTMENTS")]
    public bool cleanEnergyDepartment;

    //---Generators---\\
    [Space] [Header("GENERATORS")]
    public int hamsterWheel;

    //---BONUSES---\\
    [Space] [Header("BONUSES")]
    public ulong clicMultiplier;
}

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager instance;

    [SerializeField] private SaveData saveData;

    private void Awake()
    {
        instance = this;

        saveData = SaveManager.LoadData();
        SaveManager.Save(saveData);
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
