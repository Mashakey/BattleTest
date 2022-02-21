using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float _health;

    public void WorsenHealth(float damage)
    {
        _health -= damage;
        if (_health <= 0)
            Death();
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
