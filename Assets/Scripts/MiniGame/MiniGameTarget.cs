using UnityEngine;
using System.Collections;

public class MiniGameTarget : MonoBehaviour
{
    public Animation TargetAnimation;

    public bool HitState { get; private set; }
    private float timer = 0;
    private float hideTimer = 8.0f;

	private void Start ()
    {
        HitState = false;
        timer = 0;
        TargetAnimation.Play("up");
    }
	
	private void Update ()
    {
	    if(HitState)
        {
            timer += Time.deltaTime;
            if(timer >= hideTimer)
            {
                HitState = false;
                TargetAnimation.Play("up");
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Cocount")
        {
            timer = 0;
            HitState = true;
            TargetAnimation.Play("down");
        }
    }
}
