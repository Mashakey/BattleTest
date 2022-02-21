using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speedMove;

    [SerializeField]
    private List<GameObject> enemy;

    public List<GameObject> Enemy => enemy;

    private float distancePlayer;

    [SerializeField]
    private GameObject nearEnemy;

    public GameObject NearEnemy => nearEnemy;

    public void FindEnemy()
    {
        if (enemy.Count == 0)
        {
            GameObject[] enemyPlayer = GameObject.FindGameObjectsWithTag("Player");
            for (int i = 0; i < enemyPlayer.Length; i++)
            {
                if (enemyPlayer[i].GetComponent<Player>().TeamColor != gameObject.GetComponent<Player>().TeamColor)
                {
                    enemy.Add(enemyPlayer[i]);
                }
            }
        }
        else
            StartCoroutine(MoveEnemy());

    }

    IEnumerator MoveEnemy()
    {
        distancePlayer = Mathf.Infinity;

        foreach (GameObject oneEnemy in Enemy)
        {
            float currentDistanse = Vector3.Distance(transform.position, oneEnemy.transform.position);

            if (currentDistanse < distancePlayer)
            {
                nearEnemy = oneEnemy;
                distancePlayer = currentDistanse;
            }
        }

        transform.position = Vector3.Lerp(transform.position, nearEnemy.transform.position, _speedMove * Time.deltaTime);

        yield return new WaitForSeconds(1f);

        GetComponent<PlayerAttack>().Attack();

    }

}
