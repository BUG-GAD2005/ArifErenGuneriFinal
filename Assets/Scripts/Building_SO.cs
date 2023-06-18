using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Building")]
public class Building_SO : ScriptableObject
{
    // Coin needed to build
    public int coinCost;
    //Gem needed to build
    public int gemCost;
    //Coin this building generates over generateTime
    public int coinGen;
    //Gem this building generates over generateTime
    public int gemGen;
    //Time this building generates resources
    public float generateTime;
}
