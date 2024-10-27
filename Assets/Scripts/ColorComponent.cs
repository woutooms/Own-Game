using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ColorComponent : MonoBehaviour { 

    public EColor color;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetColor(color);
    }

    public void SetColor(EColor color)
    {
        this.color = color; 
        Color col = ColorHandler.GetColor(color);
        spriteRenderer.color = col;
    }

}
