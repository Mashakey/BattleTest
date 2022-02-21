using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerTeam : MonoBehaviour
{
    [SerializeField] 
    private List<teamIdentificationsPlayers> _teamsPlayer;

    [SerializeField]
    private UtilsController _utilsController;

    private void Awake()
    {
        _utilsController = FindObjectOfType<UtilsController>();
    }

    private void Update()
    {
        CheckDeath();
    }

    public void CheckDeath()
    {
        _teamsPlayer.RemoveAll(x => x == null);

        if (_teamsPlayer.Count <= 1)
        {
            _utilsController.PauseGame();
        }
    }
}
