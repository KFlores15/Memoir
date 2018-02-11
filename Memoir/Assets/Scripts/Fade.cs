using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Texture2D fade_out_texture;
    public float fade_speed = 1f;

    private int draw_depth = -1000;
    private float alpha = 1.0f;
    private int fade_dir = -1;

    void Awake()
    {
        fade_out_texture = new Texture2D(1, 1);
        fade_out_texture.SetPixel(0, 0, Color.black);
        GetComponent<Renderer>().material.mainTexture = fade_out_texture;
    }

    void OnGUI()
    {
        alpha += fade_dir * fade_speed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = draw_depth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fade_out_texture);
        fade_out_texture.Apply();
    }

    public float BeginFade(int direction)
    {
        fade_dir = direction;
        return (fade_speed);
    }

    void Loaded()
    {
        BeginFade(-1);
    }
}