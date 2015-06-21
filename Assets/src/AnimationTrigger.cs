using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]
public class AnimationTrigger : AnimateObjects 
{
    void OnDetect(GameObject gObject)
    {
        Animate();
    }

    void OnCollisionEnter(Collision collision)
    {
        OnDetect(collision.gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        OnDetect(collision.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        OnDetect(other.gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OnDetect(other.gameObject);
    }
}
