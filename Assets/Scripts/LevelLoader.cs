using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingBar;
    //public Slider slider;
    public Scrollbar scrollBar;
    public Button button;
    bool isPressed = false;
    //// Use this for initialization
    //void Start () {

    //}

    bool inc = true;
    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            if (inc)
                scrollBar.size = Mathf.Clamp01(scrollBar.size + Time.deltaTime);
            else
                scrollBar.size = Mathf.Clamp01(scrollBar.size - Time.deltaTime);
            if (scrollBar.size == 0 || scrollBar.size == 1)
                inc = !inc;
        }
    }

    public void LoadLevel(string scene)
    {
        if (!isPressed)
            isPressed = !isPressed;
        else
            StartCoroutine(LoadAsync(scene));
    }

    IEnumerator LoadAsync(string scene)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        loadingBar.SetActive(true);

        while (!operation.isDone)
        {
            //0- 0.9 is loading level, 0.9 - 1 is activation, aka deletes the prev scene assets?
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            scrollBar.size = progress;
            yield return null;
        }
    }
}
