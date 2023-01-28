using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampToScreen : MonoBehaviour
{
    enum ClampType { ENDLESS, FIXED}
    [SerializeField] private ClampType clampType;
    
    Vector2 screenBounds;
    
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Debug.Log(screenBounds);
    }

    void Update()
    {
        if (clampType == ClampType.ENDLESS)
        {
            Endless();
        } else
        {
            Fixed();
        }

    }

    void Endless()
    {
        if (transform.position.x > screenBounds.x)
        {
            transform.position = new Vector2(-screenBounds.x, transform.position.y);
        }

        if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        }

        if (transform.position.y > screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y);
        }

        if (transform.position.y < -screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y);
        }
    }

    void Fixed()
    {
        if (transform.position.x > screenBounds.x)
        {
            transform.position = new Vector2(screenBounds.x, transform.position.y);
        }

        if (transform.position.x < -screenBounds.x)
        {
            transform.position = new Vector2(-screenBounds.x, transform.position.y);
        }

        if (transform.position.y > screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, screenBounds.y);
        }

        if (transform.position.y < -screenBounds.y)
        {
            transform.position = new Vector2(transform.position.x, -screenBounds.y);
        }
    }
}
