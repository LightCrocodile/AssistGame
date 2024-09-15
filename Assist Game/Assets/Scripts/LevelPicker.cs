using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelPicker : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] private LevelData leveldata;

    // Triggered when the button for Level 1 is clicked
    public void OnButtonClickLevel1()
    {
        Debug.Log("Button Clicked!");  // Logs a debug message
        gameController.StartLvl();  // Starts the level using GameController
        leveldata.LoadData1();  // Loads data for Level 1
    }

    // Triggered when the button for Level 2 is clicked
    public void OnButtonClickLevel2()
    {
        Debug.Log("Button Clicked!");  // Logs a debug message
        gameController.StartLvl();  // Starts the level using GameController
        leveldata.LoadData2();  // Loads data for Level 2
    }

    // Triggered when the button for Level 3 is clicked
    public void OnButtonClickLevel3()
    {
        Debug.Log("Button Clicked!");  // Logs a debug message
        gameController.StartLvl();  // Starts the level using GameController
        leveldata.LoadData3();  // Loads data for Level 3
    }

    // Triggered when the button for Level 4 is clicked
    public void OnButtonClickLevel4()
    {
        Debug.Log("Button Clicked!");  // Logs a debug message
        gameController.StartLvl();  // Starts the level using GameController
        leveldata.LoadData4();  // Loads data for Level 4
    }

    // Triggered when the button for Level 5 is clicked
    public void OnButtonClickLevel5()
    {
        Debug.Log("Button Clicked!");  // Logs a debug message
        gameController.StartLvl();  // Starts the level using GameController
        leveldata.LoadData5();  // Loads data for Level 5
    }
}
