using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player ms_player;

    private PlayerMovement m_playerMovement;
    private PlayerGroundCheck m_playerGroundCheck;
    
    private void Awake()
    {
        ms_player = this;
    }

    private void Start()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
        m_playerGroundCheck = GetComponent<PlayerGroundCheck>();
    }

    public static PlayerMovement GetPlayerMovement()
    {
        return ms_player.m_playerMovement;
    }

    public static PlayerGroundCheck GetPlayerGroundCheck()
    {
        return ms_player.m_playerGroundCheck;
    }
    
}
