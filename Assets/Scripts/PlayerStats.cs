using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public int currentCoin = 0;
    public int currentGem = 0;
    public TMP_Text coinText;
    public TMP_Text gemText;
    
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = currentCoin.ToString();
        gemText.text = currentGem.ToString();
    }
}
