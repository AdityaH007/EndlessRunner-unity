using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gnl : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    public int r = 4; 		
    public bool creatingSection = false;
    public int secNum;
    public int t=5;
    void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
	
        secNum = Random.Range(0,r);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 45;
        yield return new WaitForSeconds(t);
        creatingSection = false;
	t+=5/2;
    }
}