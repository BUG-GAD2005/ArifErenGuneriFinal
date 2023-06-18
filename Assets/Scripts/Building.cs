using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum BuildingType
{
    pawn,
    house,
    flag,
    yacht,
    train,
    castle
}

public class Building : MonoBehaviour
{
    public BuildingType buildingType;
    [SerializeField] private Building_SO buildingData;
    private bool coroutineStarted = false;
    public bool isPlaced;
    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaced && coroutineStarted == false)
        {
            coroutineStarted = true;
            StartCoroutine(Generate());
        }
    }

    public IEnumerator Generate()
    {
        yield return new WaitForSeconds(buildingData.generateTime);
        playerStats.currentCoin += buildingData.coinGen;
        playerStats.currentGem += buildingData.gemGen;
        playerStats.coinText.text = playerStats.currentCoin.ToString();
        playerStats.gemText.text = playerStats.currentGem.ToString();
        StartCoroutine(Generate());
    }
}
