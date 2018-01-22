using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class BuyButtonScript : MonoBehaviour {

    [SerializeField]
    Button unitbutt;
    bool isBought = false;
    [SerializeField]
    GameObject confirmationPanel;

    // Use this for initialization
    void Start () {
        confirmationPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBuyButtonPress()
    {
        if (!isBought)
        {
            confirmationPanel.SetActive(true);
            //this should be the price tag
            Text nameText = unitbutt.GetComponentInChildren<Text>();
            string name = nameText.text;


            Button[] buttons = unitbutt.GetComponentsInChildren<Button>();
            Text priceText = nameText;//temp
            foreach (Button b in buttons)
            {
                if (b.name == "BuyButton")
                    priceText = b.GetComponentInChildren<Text>();
            }
            string costString = priceText.text.Substring(0, priceText.text.IndexOf(" "));
            int cost = int.Parse(costString);//safeer

            Text[] confirmationTextes = confirmationPanel.GetComponentsInChildren<Text>();
            foreach (Text t in confirmationTextes)
            {
                if (t.name == "NameText")
                    t.text = name;
                else if (t.name == "PriceText")
                    t.text = cost.ToString();
            }

            //Now the confirmation box is open
            ConfirmationBox cscript = confirmationPanel.GetComponent<ConfirmationBox>();
            cscript.AssignUnitButton(this);
        }
    }


    public Button GetUnitButton()
    {
        return unitbutt;
    }

    public void BuyUnit()
    {
        isBought = true;
    }
}
