using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AniController : MonoBehaviour
{

    public Transform[] aniTransforms;

    private int curFactors;
    Text txt_factorsNum;
    public void SetFactors(int pCurFactors) {
        curFactors = pCurFactors;
        int curNum = 0;
        if (pCurFactors > 33 && pCurFactors <= 66) curNum = 1;
        else if (pCurFactors >66) curNum = 2;
        for (int i = 0; i < 3; i++)
        {
            aniTransforms[i].gameObject.SetActive(curNum==i);
        }
        txt_factorsNum.text = pCurFactors.ToString();
    }

    public int GetFactor() 
    {
        return Int32.Parse(txt_factorsNum.text);
    }

   
    void Start()
    {
        if (aniTransforms.Length == 0) return;
        // start with normal
        txt_factorsNum = transform.Find("txt_factors").GetComponent<Text>();
        SetFactors(50);

    }

   
}
