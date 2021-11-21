using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestructor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Destroy(collision.gameObject);
        }
    }
}
