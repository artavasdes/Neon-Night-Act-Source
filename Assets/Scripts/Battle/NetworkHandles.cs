using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

public class NetworkHandles : MonoBehaviour
{
    NetworkManager manager;
    public HealthBar[] hpbars;
    // public Timer timer;

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    void Start() {
      manager.networkAddress = GlobalNetState.connectionUri;
      if (GlobalNetState.isHosting) {
        manager.StartHost();
      } else {
        manager.StartClient();
      }
    }

    // Update is called once per frame
    void Update()
    {
      if (NetworkClient.isConnected && !NetworkClient.ready) {
        NetworkClient.Ready();
        if (NetworkClient.localPlayer == null) {
            NetworkClient.AddPlayer();
        }
      }


      foreach( KeyValuePair<uint, NetworkIdentity> kvp in NetworkServer.spawned) {
        NetworkIdentity player = kvp.Value;
        Character_Control ctrl = player.GetComponent<Character_Control>();
        if (ctrl.healthBar) continue;
        for (int i = 0; i < 2; ++i) if (!hpbars[i].taken) {
          ctrl.healthBar = hpbars[i];
          ctrl.healthBar.SetVisible();
          break;
        }
      }

      if (Timer.TimeLeft > 0 && !Timer.TimerOn) {
          if (manager.numPlayers == manager.maxConnections) {
            Timer.TimerOn = true;
          }
      }


    }
}
