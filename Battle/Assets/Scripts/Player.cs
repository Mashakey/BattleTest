using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private string _teamColor;

    public string TeamColor => _teamColor;
}
