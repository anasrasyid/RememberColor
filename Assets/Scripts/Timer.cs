using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer timeObj;
    public GameObject[] timeObjects;
    public Sprite[] timeSprites;

    private SpriteRenderer spriteRenderer;
    public ColorContainer container;

    private void Awake()
    {
        timeObj = this;
    }

    public IEnumerator TimePlay(int n, float timeR)
    {
        container.ClearContainer();
        HiddenTime();
        container.SetPaint();
        yield return new WaitForSeconds(0.5f);

        ShowTime();
        container.SetLevel(n);

        while (timeR >= 0)
        { 
            SetTimeDisplay(timeR);
            timeR -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        container.ClearColor();
        GameManager.instance.isCanClick = true;

        while (!GameManager.instance.isGameOver && !GameManager.instance.isWin)
        {
            if (Mathf.Round(GameManager.instance.time) <= 0)
            {
                GameManager.instance.GameOver();
            }
            SetTimeDisplay(GameManager.instance.time);
            GameManager.instance.time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        GameManager.instance.isCanClick = false;
    }

    void SetTimeDisplay(float time)
    {
        int t = Mathf.RoundToInt(time);
        foreach(GameObject obj in timeObjects)
        {
            obj.GetComponent<SpriteRenderer>().sprite = timeSprites[t % 10];
            t = t / 10;
        }
    }

    void HiddenTime()
    {
        foreach (GameObject obj in timeObjects)
            obj.active = false;
    }

    void ShowTime()
    {
        foreach (GameObject obj in timeObjects)
            obj.active = true;
    }
}
