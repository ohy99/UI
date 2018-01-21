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
        if (overlayPanel.active == false)
        {
            //store the sender;
            this.sender = OnClickSender;
            overlayPanel.active = !overlayPanel.active;
        }
        else
        {
            if (OnClickSender.name.Substring(0, 4).Equals("Unit"))
            {
                GameObject[] units = GameObject.FindGameObjectsWithTag("SelectedUnit");
                Debug.Log(units.Length);
                bool isSelected = false;
                foreach (GameObject u in units)
                {
                    if (u.Equals(sender))
                        continue;
                    Button butt = u.GetComponent<Button>();
                    if (butt)
                    {
                        if (butt.image.sprite.Equals(OnClickSender.image.sprite))
                        {
                            //Is already selected by anotehr squad button
                            isSelected = true;
                            //do a swap
                            butt.image.sprite = this.sender.image.sprite;
                            this.sender.image.sprite = OnClickSender.image.sprite;
                            overlayPanel.active = !overlayPanel.active;
                            this.sender = null;
                            Debug.Log("SELECTED");
                            return;
                        }
                    }
                }
                if (!isSelected)
                {
                    this.sender.image.sprite = OnClickSender.image.sprite;
                }
            }

            overlayPanel.active = !overlayPanel.active;
            this.sender = null;
        }
    }
}
