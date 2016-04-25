using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public Transform PlayerTransform;
    public CharacterController PlayerChController;
    public Camera PlayerCamera;

    public float Speed = 5;
    [SerializeField]
    private Vector2 RotationSensivity;
    private Vector3 prevMousePosRel;
    // Use this for initialization
    void Start ()
    {
        prevMousePosRel = new Vector3(0.5f, 0.5f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        Move();
        RotatePlayer();
	}

    private void RotatePlayer()
    {
        Vector3 mousePosRel = PlayerCamera.ScreenToViewportPoint(Input.mousePosition);
        if(prevMousePosRel != mousePosRel)
        {
            PlayerTransform.Rotate(Vector3.up, (mousePosRel.x - prevMousePosRel.x) * RotationSensivity.x);
            PlayerCamera.transform.Rotate(Vector3.right, -(mousePosRel.y - prevMousePosRel.y) * RotationSensivity.y);
            prevMousePosRel = mousePosRel;
        }
    }

    private void Move()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if(input != Vector2.zero)
        {
            PlayerTransform.Rotate(Vector3.up, input.x);
            PlayerChController.SimpleMove(PlayerTransform.forward * input.y* Speed);
        }
    }
}
