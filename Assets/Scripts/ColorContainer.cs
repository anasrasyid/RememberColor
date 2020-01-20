using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorContainer : MonoBehaviour
{
    public GameObject[] paints;
    public GameObject[] colorsMysterius;

    public Sprite[] colors;
    public Sprite[] paintColors;

    private List<int> position = new List<int>();
    public int nColor;
    private int nPos;

    public List<int> answerColor = new List<int>();
    private int answerPos;

    public void SetPaint()
    {
        for(int i = 0; i < paints.Length; i++)
        {
            paints[i].GetComponent<SpriteRenderer>().sprite = paintColors[i];
            paints[i].GetComponent<PaintInput>().type = i;
        }
    }

    public void SetColor()
    {
        nPos = 0;
        answerPos = 0;
        answerColor.Clear();
        foreach (int pos in position)
        {
            colorsMysterius[pos].active = true;
            int type = Random.RandomRange(0, colors.Length);
            colorsMysterius[pos].GetComponent<SpriteRenderer>().sprite = colors[type];
            colorsMysterius[pos].GetComponent<SpriteRenderer>().color = Color.white;
            answerColor.Add(type);
        }
    }

    public void SetLevel(int n)
    {
        position.Clear();
        int j = (colorsMysterius.Length / 2) - (n / 2);
        for (int i = 0; i < n; i++)
        {
            position.Add(j++);
        }
        if (n % 2 == 0)
        {
            position.Add(j);
            position.Remove((colorsMysterius.Length / 2));
        }
        nColor = n;
        SetColor();
    }

    public void ClearContainer()
    {
        for (int i = 0; i < colorsMysterius.Length; i++)
        {
            colorsMysterius[i].active = false;
        }
    }

    public void AddingColor(int type)
    {
        
        if (nPos == nColor)
            return;
        if (type == answerColor[answerPos])
        {
            answerPos++;
            if (answerPos == nColor)
            {
                GameManager.instance.GameWin();
            }
                
        }
        colorsMysterius[position[nPos]].GetComponent<SpriteRenderer>().sprite = colors[type];
        colorsMysterius[position[nPos]].GetComponent<SpriteRenderer>().color = Color.white;
        nPos += 1;
    }

    public void ClearColor()
    {
        answerPos = 0;
        nPos = 0;
        foreach (int pos in position)
        {
            colorsMysterius[pos].GetComponent<SpriteRenderer>().color = new Color(0,0,0,0.3f);
        }
    }
}
