using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinText;

    private int CoinCount;
    // Start is called before the first frame update
    void Start()
    {
        CoinCount = 0;
        CoinText.text = $"Coins: {CoinCount}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GivePoints(int x)
    {
        CoinCount += x;
        CoinText.text = $"Coin: {CoinCount}";
    }   
}
