using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInfoOverlay : MonoBehaviour {

    [SerializeField]
    GameObject panel;
    [SerializeField]
    Image unitImage;

    // Use this for initialization
    void Start () {
        panel.active = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnitOverlayCallBack(Button caller)
    {
        if (!panel.active)
        {
            Debug.Log("pressle");
            unitImage.GetComponent<Image>().sprite = caller.image.sprite;
            panel.active = true;
        }
        else
        {

            panel.active = false;
        }
    }
}
