using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAudio : MonoBehaviour {

    [SerializeField]
    Slider slider;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEndDrag(AudioSource audio)
    {
        audio.volume = slider.value;
        audio.Play();
    }
}
