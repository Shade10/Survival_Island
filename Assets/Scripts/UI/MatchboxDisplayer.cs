using UnityEngine;
using UnityEngine.UI;

public class MatchboxDisplayer : MonoBehaviour
{
    public Image MatchboxImage;

    private void Start()
    {
        MatchboxImage.enabled = false;
    }

    private void Update()
    {
        if (GameplayManager.Instance.Player.HasMatchbox)
        {
            MatchboxImage.enabled = true;
        }
    }
}