using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Campfire : MonoBehaviour
{
    public Text MessageText;
    public void PointerEnter()
    {
        MessageText.text = "Patrzysz na ognisko!";
    }

    public void PointerExit()
    {
        MessageText.text = "";
    }
}
