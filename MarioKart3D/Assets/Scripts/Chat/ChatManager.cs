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
            CmdMessage(messageInput.text);
        }
    }

    [Command]
    public void CmdMessage(string message)
    {
        GameObject messageObject = GameObject.Instantiate(messagePrefab, messageList.transform);

        Text textMessageObject = messageObject.GetComponentInChildren<Text>();
        textMessageObject.text = message;
        textMessageObject.transform.localScale = Vector3.one;
        textMessageObject.rectTransform.localScale = Vector3.one;

        messageInput.ActivateInputField();

        NetworkServer.Spawn(messageObject);
    }
}
