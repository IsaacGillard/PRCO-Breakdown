using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveLoadManager : MonoBehaviour
{

    public void SaveGame()
    {
        // save player progression 
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
        Debug.Log("Saved");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        Debug.Log("Load Successful");
    }
}

