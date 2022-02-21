using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] 
    private float _damage;

    [SerializeField] 
    private float _radius;

    private GameObject enemyAtavted;

    private Vector3 _heading;

    private float _distance;

    public void Attack()
    {
        enemyAtavted = GetComponent<PlayerMovement>().NearEnemy;
         
        if (enemyAtavted != null)
        {
            _heading = enemyAtavted.transform.position - gameObject.transform.position;

            _distance = _heading.magnitude;

            if (_distance <= _radius)
            {
                enemyAtavted.GetComponent<PlayerHealth>().WorsenHealth(_damage);
            }

            GetComponent<PlayerMovement>().Enemy.Clear();
        }
        else
            FindObjectOfType<ControllerTeam>().CheckDeath();

    }
}
