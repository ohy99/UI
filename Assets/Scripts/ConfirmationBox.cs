using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationBox : MonoBehaviour {

    [SerializeField]
    GameObject confirmationBox;
    [SerializeField]
    Text coinValueText;
    [SerializeField]
    GameObject animPanel;
    BuyButtonScript script;
    //Button unit;



    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed(bool yes)
    {
        if(yes)
        {
            int currentCoin = int.Parse(coinValueText.text);
            Button unitbutt = script.GetUnitButton();
            Button[] buttons = unitbutt.GetComponentsInChildren<Button>();
            Text priceText = coinValueText;//temp
            Button priceButton = unitbutt;
            foreach (Button b in buttons)
            {
                if (b.name == "BuyButton")
                {
                    priceText = b.GetComponentInChildren<Text>();
                    priceButton = b;
                }
            }
            string costString = priceText.text.Substring(0, priceText.text.IndexOf(" "));
            int cost = int.Parse(costString);//safeer


            //check if got moneh
            if (currentCoin < cost)
            {

                return;
            }
            //Debug.Log(unitbutt.name);
            script.BuyUnit();
            currentCoin -= cost;
            coinValueText.text = currentCoin.ToString();

            //activate animation
            CoinDeduction cdScript = animPanel.GetComponent<CoinDeduction>();
            cdScript.Activate(cost);

            //adjust the buybutton accordingly
            priceText.text = "Owned";
            priceButton.interactable = false;

            script = null;
            confirmationBox.SetActive(false);
        }
        else
        {
            script = null;
            confirmationBox.SetActive(false);
        }
    }

    public void AssignUnitButton(BuyButtonScript u)
    {
        script = u;
    }
}
