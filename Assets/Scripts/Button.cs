using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public static Button instance;

    public int energyMultiplier = 1;
    public int totalEnergy;

    private void Awake()
    {
        instance = this;
    }

    public void AddEnergy(int energy)
    {
        energy *= energyMultiplier;
        totalEnergy += energy;
    }
}
