using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinC : MonoBehaviour
{
     public AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        coinFX.Play();
	CollactableControl.coinCount +=1;
        this.gameObject.SetActive(false);
    }
}
