﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDeduction : MonoBehaviour {

    [SerializeField]
    GameObject animPanel;

    double elapsedTime;
    double duration;
    double speed;
    bool isAnim;

	// Use this for initialization
	void Start () {
        Reset();
	}
	
	// Update is called once per frame
	void Update () {
        if (isAnim)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= duration)
                Reset();

            //WHY U NOT GOING UP
            animPanel.transform.localPosition.Set(animPanel.transform.localPosition.x,
                animPanel.transform.localPosition.y + (float)(speed * Time.deltaTime),
                animPanel.transform.localPosition.z);
        }
    }


    public void Activate(int value)
    {
        isAnim = true;
        animPanel.SetActive(true);
        Text aText = animPanel.GetComponentInChildren<Text>();
        aText.text = "-" + value.ToString();
    }

    public void Reset()
    {
        elapsedTime = 0.0;
        duration = 1.0;
        speed = 100.0;
        isAnim = false;
        animPanel.SetActive(false);
    }
}
