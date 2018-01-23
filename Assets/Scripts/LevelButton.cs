using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

    bool isAvailable;
    [SerializeField]
    Button button;
    //[SerializeField]
    //Image tick;

    // Use this for initialization
    void Start () {
        isAvailable = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnLevelButtonClick()
    {
        if (!isAvailable)
            return;

        //Image image = Instantiate(tick, button.transform);
        button.interactable = false;

        isAvailable = false;
    }
}
