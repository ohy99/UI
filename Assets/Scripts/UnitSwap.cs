using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSwap : MonoBehaviour {

    Button sender = null;
    [SerializeField]
    GameObject overlayPanel;

	// Use this for initialization
	void Start () {
        overlayPanel.active = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleOverlayCallback(Button OnClickSender)
    {
        overlayPanel.active = !overlayPanel.active;
        Debug.Log(overlayPanel.active);
        if (overlayPanel.active)
        {
            //store the sender;
            this.sender = OnClickSender;
        }
        else
        {
            //offing the overlay
            if(OnClickSender.name.Substring(0, 4).Equals("Unit"))
            {
                this.sender.image.sprite = OnClickSender.image.sprite;
            }
            this.sender = null;
        }
        Debug.Log(sender);
    }
}
