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
    private PlayerStateMachine m_playerStateMachine;
    private PlayerJumper m_playerJumper;
    
    private void Awake()
    {
        ms_player = this;
        m_playerMovement = GetComponent<PlayerMovement>();
        m_playerGroundCheck = GetComponent<PlayerGroundCheck>();
        m_playerStateMachine = GetComponent<PlayerStateMachine>();
        m_playerJumper = GetComponent<PlayerJumper>();
    }
    
    public static PlayerMovement GetPlayerMovement()
    {
        return ms_player.m_playerMovement;
    }

    public static PlayerGroundCheck GetPlayerGroundCheck()
    {
        return ms_player.m_playerGroundCheck;
    }
    
    public static PlayerStateMachine GetPlayerStateMachine()
    {
        return ms_player.m_playerStateMachine;
    }

    public static PlayerJumper GetPlayerJumper()
    {
        return ms_player.m_playerJumper;
    }
    
}
