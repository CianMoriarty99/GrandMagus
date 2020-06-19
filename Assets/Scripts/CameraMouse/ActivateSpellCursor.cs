using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpellCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        MouseManager.instance.ActivateSpellCursor();
    }
}
