using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player ms_player;

    private PlayerMovement m_playerMovement;

    
    private void Awake()
    {
        ms_player = this;
    }

    private void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
    }

    public PlayerMovement GetPlayerMovement()
    {
        return m_playerMovement;
    }

    
}
