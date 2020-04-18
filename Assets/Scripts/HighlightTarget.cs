using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightTarget : MonoBehaviour
{
    SpriteRenderer m_SpriteRenderer;
    GameObject mouseObjectRef;
    MouseManager mouseScriptRef;
    private string searchString;

    private Sprite [] sprites;
    
    // Start is called before the first frame update
    void Start()
    {
        mouseObjectRef = GameObject.Find("MouseManager");
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        mouseScriptRef = mouseObjectRef.GetComponent<MouseManager>();
        sprites = Resources.LoadAll<Sprite>(this.gameObject.name);

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sprites.Length > 1)
        {
            if (mouseScriptRef.selectedGameObject == this.gameObject)
            {
                m_SpriteRenderer.sprite = sprites[1]; //highlighted
            }
            else
            {
                m_SpriteRenderer.sprite = sprites[0]; //regular
            }
        }
    }
}
