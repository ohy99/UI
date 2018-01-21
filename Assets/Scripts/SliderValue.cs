using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderValue : MonoBehaviour {

    [SerializeField]
    Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnValueChangedCallBack(Text textbox)
    {
        textbox.text = (slider.value * 100).ToString("0");
    }
}
