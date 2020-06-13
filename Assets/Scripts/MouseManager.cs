using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public GameObject selectedGameObject;

    public static MouseManager instance;

    public Texture2D normal, spell, enemySelect;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selectedGameObject = null;
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector3 refPoint = new Vector3 (mousePos.x,mousePos.y, -100);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, refPoint );

        // If it hits something...
        if (hit.collider != null)
        {
            selectedGameObject = hit.transform.gameObject;
        }


    }

    public void ActivateSpellCursor()
    {
        Cursor.SetCursor(spell, Vector2.zero, CursorMode.Auto);
    }
}
