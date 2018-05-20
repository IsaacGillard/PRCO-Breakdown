using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private YieldInstruction fadeInstruction = new YieldInstruction();

    [SerializeField]
    private Image background;

	// Use this for initialization
	void Start () {

        StartCoroutine(FadeIn(background));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator FadeIn(Image image)
    {
        float elapsedTime = 0.0f;
        float fadeTime = 5.0f;
        Color c = image.color;
        while (elapsedTime < fadeTime)
        {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            c.a = Mathf.Clamp01(elapsedTime / fadeTime);
            image.color = c;
        }
    }
}
