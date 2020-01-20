using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintInput : MonoBehaviour
{
    public ColorContainer container;
    public int type;

    private void OnMouseDown()
    {
        if (!GameManager.instance.isCanClick)
            return;
        if(type == -1)
        {
            container.ClearColor();
        }
        else
        {
            container.AddingColor(type);
        }
    }
}
