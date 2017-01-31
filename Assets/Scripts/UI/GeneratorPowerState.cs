using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneratorPowerState : MonoBehaviour
{
    public Image PowerStateImage;

    public Sprite[] UIStates;

    private int currentCellsDisplayed;

    private void Start()
    {
        currentCellsDisplayed = GameplayManager.Instance.Player.CollectedCells;
        SetCorrectImage();
    }

    private void Update()
    {
        if(GameplayManager.Instance.Player.CollectedCells != currentCellsDisplayed)
        {
            currentCellsDisplayed = GameplayManager.Instance.Player.CollectedCells;
            SetCorrectImage();
        }
    }

    private void SetCorrectImage()
    {
        PowerStateImage.sprite = UIStates[currentCellsDisplayed];
    }
}
