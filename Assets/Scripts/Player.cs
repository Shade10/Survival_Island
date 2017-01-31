using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour
{
    public Transform PlayerTransform;
    public Transform CocountPosition;
    public Camera PlayerCamera;
    public Animator AnimatorComponent;
    public IK IKController;

    public float rotationSpeed = 5;
    public int CollectedCells { get; private set; }
    public bool HasMatchbox { get; private set; }
    public bool HaveCocount { get { return currentCocount != null; } }
    private Cocount currentCocount;
    private bool blockInput = false;
    private Vector3 throwStartPosition;
    private Vector3 throwStartRotaion;

    private void Start ()
    {
        CollectedCells = 0;
        HasMatchbox = false;
        blockInput = false;
        throwStartPosition = IKController.rightHandObj.localPosition;
        throwStartRotaion = IKController.rightHandObj.localRotation.eulerAngles;
    }


    private void Update ()
    {
        if (!blockInput)
        {
            Move();
            RotatePlayer();
            if (HaveCocount)
            {
                ThrowCocount();
            }
        }
    }

    private void RotatePlayer()
    {
        Ray lookAtRay = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        IKController.lookAtObj.transform.position = lookAtRay.origin + lookAtRay.direction * 10;
    }

    private void Move()
    {
        PlayerTransform.Rotate(Vector3.up, Input.GetAxis("Horizontal") *rotationSpeed);
        AnimatorComponent.SetFloat("Speed", Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimatorComponent.SetBool("IsCrouch", !AnimatorComponent.GetBool("IsCrouch"));
        }
    }

    private void ThrowCocount()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !currentCocount.HasThrown)
        {
            StartCoroutine(ThrowCoroutine());
        }
    }

    private IEnumerator ThrowCoroutine()
    {
        blockInput = true;
        Ray throwRay = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        float animationTime = 0.25f;
        bool thrown = false;
        for (float time = 0; time < animationTime; time += Time.deltaTime)
        {
            IKController.rightHandObj.localPosition = Vector3.Lerp(throwStartPosition, IKController.throwPoint1.localPosition, time/animationTime);
            IKController.rightHandObj.localRotation = Quaternion.Euler(Vector3.Lerp(throwStartRotaion, IKController.throwPoint1.localRotation.eulerAngles, time/animationTime));
            yield return 0;
        }
        for (float time = 0; time < animationTime; time += Time.deltaTime)
        {
            if (!thrown && time > animationTime * 0.75f)
            {
                currentCocount.Throw(throwRay);
                thrown = true;
            }
            IKController.rightHandObj.localPosition = Vector3.Lerp(IKController.throwPoint1.localPosition, IKController.throwPoint2.localPosition, time / animationTime);
            IKController.rightHandObj.localRotation = Quaternion.Euler(Vector3.Lerp(IKController.throwPoint1.localRotation.eulerAngles, IKController.throwPoint2.localRotation.eulerAngles, time / animationTime));
            yield return 0;
        }
        blockInput = false;
        IKController.rightHandObj.localPosition = throwStartPosition;
        IKController.rightHandObj.localRotation = Quaternion.Euler(throwStartRotaion);
    }

    public void AddCocount(Cocount cocount)
    {
        currentCocount = cocount;
        cocount.transform.SetParent(CocountPosition);
        cocount.transform.localPosition = Vector3.zero;
        IKController.rightHandWeightPosition = 1;
        IKController.rightHandWeightRotation = 1;
    }

    public void RemoveCocount()
    {
        if(currentCocount != null)
        {
            Destroy(currentCocount.gameObject);
        }
        currentCocount = null;
        IKController.rightHandWeightPosition =0;
        IKController.rightHandWeightRotation = 0;
    }

    public void CollectCell()
    {
        CollectedCells++;
    }

    public void GetMatchbox()
    {
        HasMatchbox = true;
    }

    public void UseMatchbox()
    {
        HasMatchbox = false;
        AnimatorComponent.SetBool("IsCrouch", true);
    }

    public void StandUp()
    {
        AnimatorComponent.SetBool("IsCrouch", false);
    }
}
