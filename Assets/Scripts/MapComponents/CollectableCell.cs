using UnityEngine;
using System.Collections;

public class CollectableCell : MonoBehaviour
{
    public Transform CellTransform;

    [SerializeField]
    private float RotationSpeed;

    private void Update()
    {
        CellTransform.Rotate(Vector3.right * RotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameplayManager.Instance.Player.CollectCell();
            Destroy(gameObject);
        }
    }
}
