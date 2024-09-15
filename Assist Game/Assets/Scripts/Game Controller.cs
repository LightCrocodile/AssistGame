using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class GameController : MonoBehaviour
{

    [SerializeField] CountDownTimer lvl;
    [SerializeField] GameObject lvlscene;
    [SerializeField] GameObject levelPicker;
    [SerializeField] Camera lvlpcam;
    [SerializeField] Slot slot;



    // Start is called before the first frame update
    private void Start()
    {

        levelPicker.SetActive(true);
        lvl.Levelend += EndLvl;
        slot.Levelend += EndLvl;
    }

    // This method is called when the level ends (triggered by the Levelend event)
    public void EndLvl()
    {

        levelPicker.SetActive(true);
        lvlscene.SetActive(false);
        lvl.GameOver.SetActive(false);
    }

    // Method to start the level when the player selects a level
    public void StartLvl()
    {

        levelPicker.SetActive(false);
        lvlscene.SetActive(true);
        StartCoroutine(lvl.HandleUpdate());
    }
}
