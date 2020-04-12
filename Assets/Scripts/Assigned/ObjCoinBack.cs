using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCoinBack : MonoBehaviour
{
    public int Coins;
    public ObjText Target;
    internal void UpdateCoins(int coins, ObjText target)
    {
        Coins = coins;
        Target = target;
    }
}
