using System.Collections;
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
    float starting_y = 0.0f;

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


            Vector3 temp = animPanel.transform.localPosition;

            if (starting_y == 0.0f)
                starting_y = temp.y;

            temp.y += (float)(speed * Time.deltaTime);
            //WHY U NOT GOING UP
            animPanel.transform.localPosition = temp;
        }
    }


    public void Activate(int value)
    {
        isAnim = true;
        animPanel.SetActive(true);
        Text aText = animPanel.GetComponentInChildren<Text>();
        aText.text = "-" + value.ToString();

        Vector3 temp = animPanel.transform.localPosition;
        temp.y = starting_y;
        animPanel.transform.localPosition = temp;
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
