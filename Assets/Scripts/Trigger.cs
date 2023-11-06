using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        Color thisColor = GetComponent<SpriteRenderer>().color;
        this.GetComponent<SpriteRenderer>().color = other.GetComponent<SpriteRenderer>().color;
        other.GetComponent<SpriteRenderer>().color = thisColor;
    }
}
