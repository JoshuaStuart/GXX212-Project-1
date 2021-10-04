using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBubble : MonoBehaviour
{
    public int value;
    public Color32 colour;

    public Text valueTXT;


    /// <summary>
    /// To be used by another script when making a UI bubble
    /// </summary>
    /// <param name="OriginValue"></param>
    /// <param name="mat"></param>
    public void GenerateBubble(int OriginValue, Material mat)
    {
        value = OriginValue;
        colour = mat.color;


        GetComponent<Image>().color = colour;
        valueTXT.text = value.ToString();
    }
}
