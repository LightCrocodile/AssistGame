using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LevelData : MonoBehaviour
{
    [SerializeField] private GameObject[] unitGameObjects;  // Array of game objects representing units in the level
    [SerializeField] private LevelPicker levelPicker;  // Reference to the LevelPicker script
    [SerializeField] CountDownTimer countDownTimer;
    private List<IUnit> units;  // List of IUnit objects to manage unit data

    private void Awake()
    {
        units = new List<IUnit>();  // Initialize the units list

        // Loop through each GameObject in unitGameObjects and add the IUnit component to the units list
        foreach (GameObject unitGameObject in unitGameObjects)
        {
            IUnit unit = unitGameObject.GetComponent<IUnit>();  // Try to get the IUnit component
            if (unit != null)
            {
                units.Add(unit);  // Add to units list if the component is found
            }
            else
            {
                Debug.LogWarning("GameObject does not have an IUnit component: " + unitGameObject.name);
            }
        }


    }

    private void Update()
    {
        // Save the data when the "S" key is pressed
        if (Input.GetKeyUp(KeyCode.S))
        {
            Save();
        }
    }

    // Load data for Level 1
    public void LoadData1()
    {
        Load("Level1.json");
    }

    // Load data for Level 2
    public void LoadData2()
    {
        Load("Level2.json");
    }

    // Load data for Level 3
    public void LoadData3()
    {
        Load("Level3.json");
    }

    // Load data for Level 4
    public void LoadData4()
    {
        Load("Level4.json");
    }

    // Load data for Level 5
    public void LoadData5()
    {
        Load("Level5.json");
    }

    // Save the current unit positions to a JSON file
    private void Save()
    {
        List<SaveObject> saveObjects = new List<SaveObject>();  // List to store position data

        // Iterate over each unit and create a SaveObject for their position
        foreach (IUnit unit in units)
        {
            Vector3 position = unit.GetPosition();  // Get the position of the unit
            SaveObject saveObject = new SaveObject
            {
                pos = position
            };
            saveObjects.Add(saveObject);  // Add the SaveObject to the list
        }

        SaveData saveData = new SaveData
        {
            positions = saveObjects.ToArray()  // Convert the list to an array and store it in SaveData
        };
        string json = JsonUtility.ToJson(saveData, true);  // Convert the SaveData object to a JSON string

        // Ensure the folder for saved data exists
        string folderPath = Path.Combine(Application.dataPath, "SavedData");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // Write the JSON data to the file
        string filePath = Path.Combine(folderPath, "Level4.json");
        File.WriteAllText(filePath, json);

        Debug.Log("Data saved to: " + filePath);  // Log the save path
    }

    // Load the saved data from a JSON file
    private void Load(string fileName)
    {
        // Get the file path for the saved data
        string folderPath = Path.Combine(Application.dataPath, "SavedData");
        string filePath = Path.Combine(folderPath, fileName);

        if (File.Exists(filePath))
        {
            // Read the data from the file and deserialize it into a SaveData object
            string saveString = File.ReadAllText(filePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(saveString);



            countDownTimer.currentTime = saveData.timer;


            Debug.Log("Loaded timer value: " + saveData.timer);

            // Check if the number of saved positions matches the number of units
            if (saveData.positions.Length == units.Count)
            {
                for (int i = 0; i < units.Count; i++)
                {
                    units[i].SetPosition(saveData.positions[i].pos);  // Set the position of each unit

                }
                Debug.Log("Data loaded from: " + filePath);
            }
            else
            {
                Debug.LogWarning("Mismatch between saved positions and current units count.");
            }

        }
        else
        {
            Debug.LogWarning("Save file not found at: " + filePath);
        }

    }

    // Class to represent each saved object's position
    [System.Serializable]
    private class SaveObject
    {
        public Vector3 pos;  // Stores the position of the unit

    }

    // Class to hold all the saved data (an array of SaveObject instances)
    [System.Serializable]
    private class SaveData
    {
        public SaveObject[] positions;  // Array of saved positions
        public int timer;
        public string Difficulty;
    }
}
