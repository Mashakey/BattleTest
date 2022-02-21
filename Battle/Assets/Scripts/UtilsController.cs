using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UtilsController : MonoBehaviour
{
    private GameTimeController _gameTimeController;

    [SerializeField]
    private GameObject _restartPanel;

    [SerializeField]
    private TextMeshProUGUI winer;

    private void Awake()
    {
        _gameTimeController = new GameTimeController();
    }

    public void StartGame()
    {
        _gameTimeController.UnpauseGame();
        _restartPanel.SetActive(false);
    }

    public void PauseGame()
    {
        _gameTimeController.PauseGame();
        _restartPanel.SetActive(true);
        FindObjectOfType<Timer>().StopTimer();
        winer.text =$"Победила команда: {FindObjectOfType<Player>().TeamColor}";
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
