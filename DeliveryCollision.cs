using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCollision : MonoBehaviour
{
    [SerializeField] Color32 hasPassengerColor = new Color32 (188, 133, 116, 255);
    [SerializeField] Color32 noPassengerColor = new Color32 (1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    bool hasPassenger;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Crash!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Passenger" && !hasPassenger) 
        {
            Debug.Log("Passenger picked up.");
            hasPassenger = true;
            spriteRenderer.color = hasPassengerColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if (other.tag == "Destination" && hasPassenger)
        {
            Debug.Log("Destination reached.");
            hasPassenger = false;
            spriteRenderer.color = noPassengerColor;
        }
    }
}

