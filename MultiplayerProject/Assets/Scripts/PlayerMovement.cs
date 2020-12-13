using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour
{

    [SyncVar(hook = nameof(OnHolaCountChange))]
    int holaCount = 0;

  void HandleMovement()
    {
        if (isLocalPlayer)
        {
            //Do something
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(moveHorizontal * 0.1f, moveVertical * 0.1f, 0);
            transform.position = transform.position + movement;



        }
    }


    private void Update()
    {
        HandleMovement();
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Send to a server HOLA!");
            Hola();
        }
        if(isServer && transform.position.y > 50)
        {
            TooHigh();
        }
    }



    [Command]
    void Hola()
    {
        Debug.Log("Received HOLA from clien!");
        holaCount++;
        RepplyHola(); 

    }

    [TargetRpc]
    void RepplyHola()
    {
        Debug.Log("ReceiveHola");
    }

    [ClientRpc]
    void TooHigh()
    { 
        Debug.Log("Too High");
    }


    void OnHolaCountChange(int oldCount, int newCount)
    {
        Debug.Log($"We had {oldCount} holas, but now we have {newCount} holas");
    }
}
