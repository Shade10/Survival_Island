using UnityEngine;
using System.Collections;

public class MiniGameTrigger : MonoBehaviour
{
    public Transform CocountPrefab;

    private Player player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (player == null)
            {
                player = other.GetComponent<Player>();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && !player.HaveCocount)
        {
            Cocount cocount = Instantiate(CocountPrefab).GetComponent<Cocount>();
            player.AddCocount(cocount);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            player.RemoveCocount();
        }
    }
}
