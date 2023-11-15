using System.Collections;
using System.Collections.Generic;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine;

public class CollactableControl : MonoBehaviour
{
    public static int coinCount;
    public TextMeshProUGUI coinCountDisplay; // Use TextMeshProUGUI for UI text

    void Update()
    {
        if (coinCountDisplay != null)
        {
            coinCountDisplay.text = coinCount.ToString();
        }
    }
}
