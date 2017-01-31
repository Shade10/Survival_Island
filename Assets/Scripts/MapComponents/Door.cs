using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Door : MonoBehaviour
{
    public Animation AnimationComponent;

    private bool energyAvailable { get { return GameplayManager.Instance.Player.CollectedCells >= 4; } }
    private bool doorClosed = true;
    private bool playerStayInTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (energyAvailable)
            {
                if (doorClosed)
                {
                    AnimationComponent.Play("dooropen");
                    doorClosed = false;
                }
            }
            else
            {
                GameplayManager.Instance.Message.ShowMessage("Drzwi zamknięte, brak zasilania!", true);
            }
            playerStayInTrigger = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        GameplayManager.Instance.Message.HideMessage("Drzwi zamknięte, brak zasilania!");
        playerStayInTrigger = false;
        Invoke("CloseDoor", 2);
    }

    private void CloseDoor()
    {
        if(!playerStayInTrigger && !doorClosed)
        {
            AnimationComponent.Play("doorshut");
            doorClosed = true;
        }
    }
}
