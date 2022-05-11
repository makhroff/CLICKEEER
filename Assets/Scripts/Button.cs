using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ulong energyMultiplier = 1;

    public void AddEnergy(int energyToAdd)
    {
        energyToAdd *= (int)energyMultiplier;
        EnergyManager.instance.AddEnergy((ulong)energyToAdd);
    }
}
