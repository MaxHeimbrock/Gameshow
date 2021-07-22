using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSolutionButton : MonoBehaviour
{
    private bool clicked = false;
    private Image image;

    public void Start()
    {
        image = GetComponent<Image>();
    }

    public void Clicked()
    {
        clicked = !clicked;

        if (clicked)
        {
            ShowSolution();
        }
        else if (!clicked)
        {
            HideSolution();
        }
    }

    private void HideSolution()
    {
        this.image.color = Color.clear;
    }

    private void ShowSolution()
    {
        this.image.color = Color.white;
    }
}
