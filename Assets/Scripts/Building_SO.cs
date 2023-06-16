using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Building")]
public class Building_SO : ScriptableObject
{
    public string buildingName;
    public Sprite buildingSprite;

    public int costCoin;
    public int costGem; 
    public int gainCoin;
    public int gainGem;

    public float generateTime;
}
