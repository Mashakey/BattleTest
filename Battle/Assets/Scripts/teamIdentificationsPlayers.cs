using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamIdentificationsPlayers : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _players;

    private void Awake()
    {
        FindPlayersTeam();
    }

    private void Update()
    {
        if (!CheckTeamsCount())
        {
            Destroy(gameObject);
        }

        foreach (GameObject onePlayer in _players)
        {
            onePlayer.GetComponent<PlayerMovement>().FindEnemy();
        }
    }

    private void FindPlayersTeam()
    {
        for(int i = 0; i < gameObject.transform.childCount; i++)
        {
            var player = gameObject.transform.GetChild(i);
            _players.Add(player.gameObject);
        }
    }

    private bool CheckTeamsCount()
    {
        _players.RemoveAll(x => x == null);

        if (_players.Count > 0)
            return true;

        return false;
    }

    public IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(1f);

        foreach (GameObject onePlayer in _players)
        {
            onePlayer.GetComponent<PlayerMovement>().FindEnemy();
        }
    }
}
