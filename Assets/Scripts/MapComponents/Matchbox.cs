using UnityEngine;

public class Matchbox : MonoBehaviour
{
    private bool lookAtMatchbox = false;

    public void PointerEnter()
    {
        lookAtMatchbox = true;
    }

    public void PointerExit()
    {
        lookAtMatchbox = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && lookAtMatchbox)
        {
            GameplayManager.Instance.Message.ShowMessage("Naciśnij LPM, aby podnieść zapałki", false);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameplayManager.Instance.Player.GetMatchbox();
                OnTriggerExit(other);
                Destroy(gameObject);
            }
        }
        else
        {
            OnTriggerExit(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        GameplayManager.Instance.Message.HideMessage("Naciśnij LPM, aby podnieść zapałki");
    }
}