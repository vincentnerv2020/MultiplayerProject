using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    //Server
    public override void OnStartServer()
    {
        Debug.Log("Server is Started");
    }

    public override void OnStopServer()
    {
        Debug.Log("Server stopped!");
    }

    //Client
    public override void OnClientConnect(NetworkConnection conn)
    {
        Debug.Log("Client Connected");
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        Debug.Log("Client disconnected");
    }

}
