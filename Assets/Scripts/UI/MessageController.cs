using UnityEngine;
using UnityEngine.UI;

public class MessageController : MonoBehaviour
{
    public Text MessageText;

    public void ShowMessage(string message, bool force)
    {
        if(force || MessageText.text == "")
        {
            MessageText.text = message;
        }
    }

    public void HideMessage(string message)
    {
        if(MessageText.text.Equals(message))
        {
            MessageText.text = "";
        }
    }
}