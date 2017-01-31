using System;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public MeshRenderer GeneratorStateRenderer;

    public Texture[] GeneratorStates;

    private int currentCellsDisplayed;

    private void Start()
    {
        currentCellsDisplayed = GameplayManager.Instance.Player.CollectedCells;
        SetCorrectImageTexture();
    }

    private void Update()
    {
        if (GameplayManager.Instance.Player.CollectedCells != currentCellsDisplayed)
        {
            currentCellsDisplayed = GameplayManager.Instance.Player.CollectedCells;
            SetCorrectImageTexture();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (currentCellsDisplayed < 4)
            {
                GameplayManager.Instance.Message.ShowMessage("Generator energetyczny naładowany w " + GetProcentageOfEnergy(), false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        GameplayManager.Instance.Message.HideMessage("Generator energetyczny naładowany w " + GetProcentageOfEnergy());
    }

    private void SetCorrectImageTexture()
    {
        GeneratorStateRenderer.material.mainTexture = GeneratorStates[currentCellsDisplayed];
    }

    private string GetProcentageOfEnergy()
    {
        return currentCellsDisplayed*25 + "%";
    }
}