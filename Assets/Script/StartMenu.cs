using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public RectTransform Background;
    public RectTransform MenuDisplay;
    public bool MainMenuEnable;
    // Start is called before the first frame update
    public void TurnOffUI()
	{
        Background.gameObject.SetActive(false);
        MenuDisplay.gameObject.SetActive(false);
        MainMenuEnable = false;

    }
    public void TurnOnUI()
	{
        Background.gameObject.SetActive(true);
        MenuDisplay.gameObject.SetActive(true);
        MainMenuEnable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            TurnOffUI();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            TurnOnUI();
        }
    }
}
