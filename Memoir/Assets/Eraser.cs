using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser : MonoBehaviour {

    //private Color transparentColor;
    private Texture2D texture;
    private Sprite sprite;
    private Rect rect;
    private Color[] colors, texture_colors;

    public Texture2D target;
    public float range;

    // Use this for initialization
    void Start () {
        range = 20f;

        colors = GetComponent<SpriteRenderer>().sprite.texture.GetPixels(0);
        rect = GetComponent<SpriteRenderer>().sprite.rect;
        texture = new Texture2D(Mathf.RoundToInt(rect.width), Mathf.RoundToInt(rect.height));
        sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));
        GetComponent<SpriteRenderer>().sprite = sprite;

        texture_colors = texture.GetPixels(0);
        for (int i = 0; i < texture_colors.Length; i++)
            texture_colors[i] = colors[i];
        texture.SetPixels(texture_colors, 0);
        texture.Apply();
        
    }
	
	// Update is called once per frame
	void Update () {

        if (!Input.GetMouseButton(0))
            return;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider == null)
            return;

        int mouseX = (int)((hit.point.x + 2) / 4 * texture.width);
        int mouseY = (int)((hit.point.y + 1.115) / 2.23 * texture.height);

        Debug.Log(hit.collider.bounds);

        for (int i = (int)(-range); i < range; i++)
        {
            for (int j = (int)(-range); j < range; j++)
            {
                if (mouseX + i < 0 || mouseX + i > texture.width || mouseY + j < 0 || mouseY + j > texture.height)
                    break;

                if (Mathf.Sqrt((Mathf.Pow((float)(i), 2)) + (Mathf.Pow((float)(j), 2))) < range)
                GetComponent<SpriteRenderer>().sprite.texture.SetPixel(mouseX + i, mouseY + j, target.GetPixel(mouseX + i, mouseY + j));
            }
        }
        texture.Apply();

    }
}
