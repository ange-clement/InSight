using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int startLevelIndex = 2;

    public Button imgStart;
    public Button imgContinue;
    public Button imgLevelSelect;

    public float fadingTime = 0.5f;
    public Image fadingImage;

    public GameObject MainMenu;
    public GameObject LevelMenu;

    public Button butonLevelPrefab;

    private bool isLoading = false;
    private float fadingSpeed;

    void Start()
    {
        LevelData.ReadLevelData();
        if (LevelData.MaxLevel == 0)
        {
            imgContinue.interactable = false;
            imgLevelSelect.interactable = false;
        }

        Debug.Log("MaxLevel = "+LevelData.MaxLevel);
    }

    public void ButtonStart()
    {
        LevelData.Level = startLevelIndex;
        LaunchFade();
    }

    public void ButtonContinue()
    {
        LevelData.Level = LevelData.MaxLevel;
        LaunchFade();
    }

    public void ButtonLevelSelect()
    {
        MainMenu.SetActive(false);
        LevelMenu.SetActive(true);

        for (int i = startLevelIndex; i < LevelData.MaxLevel; i++)
        {
            int level = i;
            Button b = Instantiate<Button>(butonLevelPrefab, LevelMenu.transform);
            b.GetComponentInChildren<TextMeshProUGUI>().text = "Level " + i;
            b.onClick.AddListener(delegate { ButtonLevel(level); });
        }
    }

    public void ButtonLevel(int l)
    {
        LevelData.Level = l;
        LaunchFade();
    }

    private void LaunchFade()
    {
        if (!isLoading)
        {
            isLoading = true;
            fadingSpeed = 1.0f / fadingTime;
            StartCoroutine(FadeThenLoad());
        }
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

        LevelData.LoadLevel();
    }
}
