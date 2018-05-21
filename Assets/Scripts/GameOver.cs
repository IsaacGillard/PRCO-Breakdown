using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private YieldInstruction fadeInstruction = new YieldInstruction();

    [SerializeField]
    private Transform Player;

    [SerializeField]
    private Image background;

    [SerializeField]
    private GameObject Restart;

    [SerializeField]
    private GameObject Menu;

    private bool imageAlpha = false;

    float elapsedTime = 0.0f;
    float fadeTime = 3.0f;

    // Use this for initialization
    void Start () {

        StartCoroutine(FadeIn(background));
        Player.GetComponent<FirstPersonController>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        // slowly fade to black
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (elapsedTime >= 3)
        {
            imageAlpha = true;
        }

        if (imageAlpha == true)
        {
            Restart.SetActive(true);
            Menu.SetActive(true);
        }
		
	}

    IEnumerator FadeIn(Image image)
    {
        // slowly fade to black
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
        
        
    }

    public void RestartLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
