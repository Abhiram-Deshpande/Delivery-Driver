using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float steerSpeed = 0.1f;
    [SerializeField] private float moveSpeed = 5f;
    private Space[] relativeArr = {Space.World,Space.Self};
    [SerializeField]private bool isRelativeTo = true;

    


    void LateUpdate()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float translationAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, 0f, -steerAmount,relativeArr[Convert.ToInt32(isRelativeTo)]);
        transform.Translate(0f, translationAmount, 0f);
        //Debug.Log(Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("boost") && moveSpeed>15)
        {
            Debug.Log("Increasing the move speed");
            moveSpeed+=10f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed -= 15f;
    }
}
