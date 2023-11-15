using System.Collections;
using UnityEngine;
using TMPro;

public class LevelDistance : MonoBehaviour
{
    public GameObject disdisplay;
    public int disRun;
    public bool addingdis = false;
    public float disdelay = 0.45f;

    // Flag to indicate whether counting should continue
    private bool continueCounting = true;

    void Update()
    {
        if (addingdis == false && continueCounting)
        {
            addingdis = true;
            StartCoroutine(Adding());
        }
    }

    IEnumerator Adding()
    {
        disRun += 1;
        disdisplay.GetComponent<TextMeshProUGUI>().text = "" + disRun;
        yield return new WaitForSeconds(disdelay);
        addingdis = false;
    }

    // Call this method to stop counting
    public void StopCounting()
    {
        continueCounting = false;
    }
}
