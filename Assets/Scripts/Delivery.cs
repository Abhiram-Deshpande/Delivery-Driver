using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool isPackagePickedUp = false;
    [SerializeField][Range(1,6)]private float destroyDelay = 0.1f;
    private Color32 _originalColor;

    private void Start()
    {
        _originalColor = GetComponent<SpriteRenderer>().color;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("package"))
        {
            if (isPackagePickedUp)
            {
                Debug.Log("Cannot pick up a package while already having another package");
            }
            else
            {
                isPackagePickedUp = !isPackagePickedUp;
                GetComponent<SpriteRenderer>().color = other.GetComponent<SpriteRenderer>().color;
                Debug.Log("Package picked up");
                Destroy(other.gameObject,destroyDelay);    
            }

            
        }

        if (other.CompareTag("customer") && isPackagePickedUp)
        {
            Debug.Log("Package Delivered");
            isPackagePickedUp = !isPackagePickedUp;
            RevertColor();
        }
        else
        {
            if(!isPackagePickedUp) Debug.Log("Package not picked up yet...");
        }
    }

    private void RevertColor()
    {
        this.GetComponent<SpriteRenderer>().color = _originalColor;
    }
}
