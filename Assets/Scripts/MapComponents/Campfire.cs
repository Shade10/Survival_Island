using UnityEngine;

public class Campfire : MonoBehaviour
{
    public ParticleSystem Fire;
    public ParticleSystem Smoke;

    private bool lookAtCampfire = false;

    public void PointerEnter()
    {
        GameplayManager.Instance.Message.ShowMessage("Patrzysz na ognisko!", false);
        lookAtCampfire = true;
    }

    public void PointerExit()
    {
        GameplayManager.Instance.Message.HideMessage("Patrzysz na ognisko!");
        lookAtCampfire = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && lookAtCampfire && GameplayManager.Instance.Player.HasMatchbox)
        {
            GameplayManager.Instance.Message.ShowMessage("Naciśnij LPM, aby rozpalić ognisko", true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                MakeFire();
                OnTriggerExit(other);
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
        GameplayManager.Instance.Message.HideMessage("Naciśnij LPM, aby rozpalić ognisko");
    }

    private void MakeFire()
    {
        Fire.Play();
        Smoke.Play();
        GameplayManager.Instance.EndGame();
    }
}
