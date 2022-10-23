using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : Actionable
{
    public float fadingTime = 0.5f;
    public Image fadingImage;

    private bool isLoading = false;
    private float fadingSpeed;

    public override void Activate()
    {
        if (!isLoading)
        {
            isLoading = true;
            fadingSpeed = 1.0f / fadingTime;
            StartCoroutine(FadeThenLoad());
        }
    }

    public override void Deactivate()
    {

    }

    IEnumerator FadeThenLoad()
    {
        while (fadingImage.color.a < 1.0f)
        {
            Color newColor = fadingImage.color;
            newColor.a += fadingSpeed * Time.deltaTime;
            fadingImage.color = newColor;

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(fadingTime);

        LevelData.LoadNextLevel();
    }
}
