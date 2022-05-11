using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public int energyMultiplier = 1;

    public void AddEnergy(int energyToAdd)
    {
        energyToAdd *= energyMultiplier;
        EnergyManager.instance.AddEnergy((ulong)energyToAdd);
    }
}
