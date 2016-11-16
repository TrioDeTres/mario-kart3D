using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChatManager : NetworkBehaviour
{
    public GameObject messageList;
    public GameObject messagePrefab;
    public InputField messageInput;

    public void SendMessage()
    {
        if (messageInput.text.Length > 0)
        {
            print(hasAuthority);
            print(connectionToClient);
            print(connectionToServer);
            CmdMessage(messageInput.text);
        }
    }

    [Command]
    public void CmdMessage(string message)
    {
        GameObject messageObject = Instantiate(messagePrefab, messageList.transform, false);
        
        Text textMessageObject = messageObject.GetComponentInChildren<Text>();
        textMessageObject.text = message;

        messageInput.text = string.Empty;
        messageInput.Select();
        messageInput.ActivateInputField();

        NetworkServer.Spawn(messageObject);
    }
}
