using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    [SerializeField] Color activatedColor;
    [SerializeField] Color highlightedColor;

    private MeshRenderer meshRenderer;
    private Material mat;
    private Color startColor;

    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        mat = meshRenderer.material;
        startColor = mat.color;
    }

    public void changeColor(Color color)
    {
        mat.color = color;
    }

    public void changeColor(string color)
    {
        switch (color)
        {
            case "activatedColor":
                mat.color = activatedColor;
                break;
            case "highlightedColor":
                mat.color = highlightedColor;
                break;
            default:
                mat.color = startColor;
                break;
        }
    }

    public void resetColor()
    {
        mat.color = startColor;
    }
}
