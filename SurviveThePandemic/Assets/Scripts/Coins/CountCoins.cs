using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TEXTMESH PRO
using UnityEngine.UI;
using TMPro;

public class CountCoins : MonoBehaviour
{
    public int Coins = 0;
    public TextMeshProUGUI nCoins;

    // Update is called once per frame
    void Update()
    {
        nCoins.text = "$" + Coins;
    }
}
