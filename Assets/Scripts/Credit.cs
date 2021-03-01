using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Credit : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CreditText;

    private int CreditCount;
    // Start is called before the first frame update
    void Start()
    {
        CreditCount = 0;
        CreditText.text = $"Credit: {CreditCount}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GivePoints(int x)
    {
        CreditCount += x;
        CreditText.text = $"Credit: {CreditCount}";
    }
}
