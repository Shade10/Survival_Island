using UnityEngine;
using System.Collections;

public class MiniGameManager : MonoBehaviour
{
    public MiniGameTarget FirstTarget;
    public MiniGameTarget SecondTarget;
    public MiniGameTarget ThirdTarget;
    public GameObject PowerCell;

    private bool GameWon = false;

    private void Update()
    {
        if (!GameWon && FirstTarget.HitState && SecondTarget.HitState && ThirdTarget.HitState)
        {
            GameWon = true;
            Destroy(PowerCell);
            Player player = FindObjectOfType<Player>();
            if(player != null)
            {
                player.CollectCell();
            }
        }
    }
}
