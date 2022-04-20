using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 25f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    public void ReturnSpeed()
    {
        moveSpeed = 20f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bush")
        {
            moveSpeed = slowSpeed;
            Invoke("ReturnSpeed", 4);
        }
        
        if(other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
            Invoke("ReturnSpeed", 4);
        }

    }
}
