using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player ms_player;

    private PlayerMovement m_playerMovement;
    private PlayerGroundCheck m_playerGroundCheck;
    private PlayerStateMachine m_playerStateMachine;
    private PlayerJumper m_playerJumper;
    private DownDasher m_downDasher;
    private GravityScaleController m_gravityScaleController;
    private PlayerTeleportStarter m_playerTeleportStarter;
    
    private void Awake()
    {
        ms_player = this;
        m_playerMovement = GetComponent<PlayerMovement>();
        m_playerGroundCheck = GetComponent<PlayerGroundCheck>();
        m_playerStateMachine = GetComponent<PlayerStateMachine>();
        m_playerJumper = GetComponent<PlayerJumper>();
        m_downDasher = GetComponent<DownDasher>();
        m_gravityScaleController = GetComponent<GravityScaleController>();
        m_playerTeleportStarter = GetComponent<PlayerTeleportStarter>();
    }

    public static PlayerTeleportStarter GetPlayerTeleportStarter()
    {
        return ms_player.m_playerTeleportStarter;
    }

    public static GravityScaleController GetGravityScaleController()
    {
        return ms_player.m_gravityScaleController;
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

    public static DownDasher GetDownDasher()
    {
        return ms_player.m_downDasher;
    }
    
}
