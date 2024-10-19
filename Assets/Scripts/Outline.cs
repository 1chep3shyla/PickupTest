using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    [SerializeField]
    private Renderer[] objectRenderers; 
    private Color[] originalColors;    
    public Color highlightColor = Color.yellow;

    void Awake()
    {
        if (objectRenderers != null && objectRenderers.Length > 0)
        {
            originalColors = new Color[objectRenderers.Length];
            for (int i = 0; i < objectRenderers.Length; i++)
            {
                originalColors[i] = objectRenderers[i].material.color;
            }
        }
    }

    public void SetHighlight(bool state)
    {
        if (objectRenderers != null && objectRenderers.Length > 0)
        {
            for (int i = 0; i < objectRenderers.Length; i++)
            {
                objectRenderers[i].material.color = state ? highlightColor : originalColors[i];
            }
        }
    }
}