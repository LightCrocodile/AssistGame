using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelData levelData;
    [SerializeField] private int currentLevel = 1;

    private void Start()
    {
        LoadLevelData(currentLevel);
    }

    private void LoadLevelData(int level)
    {
        switch (level)
        {
            case 1:
                levelData.LoadData1();
                break;
            case 2:
                levelData.LoadData2();
                break;
            case 3:
                levelData.LoadData3();
                break;
            case 4:
                levelData.LoadData4();
                break;
            case 5:
                levelData.LoadData5();
                break;
            default:
                Debug.LogWarning("No data available for this level.");
                break;
        }
    }

    public void CompleteLevel()
    {
        currentLevel++;
        if (currentLevel <= 5)
        {
            LoadLevelData(currentLevel);
        }
        
    }
}
