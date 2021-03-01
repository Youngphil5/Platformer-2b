using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI PointsText;

    private int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        PointsText.text = $"Points: {points}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GivePoints(int x)
    {
        points += x;
        PointsText.text = $"Points: {points}";
    }
}
