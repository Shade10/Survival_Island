using UnityEngine;
using System.Collections;

public class Cocount : MonoBehaviour
{
    public Rigidbody CocountRigidbody;

    public bool HasThrown { get; private set; }

    public float LiveTime = 2;
    public float ThrowStrength = 10;
    private float timer = 0;
    private float maxDistance = 10;

	private void Start()
    {
        HasThrown = false;
	}
	
	private void Update()
    {
	    if(HasThrown)
        {
            timer += Time.deltaTime;
            if(timer >= LiveTime)
            {
                Destroy(gameObject);
            }
        }
	}

    public void Throw(Ray shotRay)
    {
        HasThrown = true;
        CocountRigidbody.velocity = (GetThrowPoint(shotRay) - transform.position).normalized * ThrowStrength;
        CocountRigidbody.isKinematic = false;
        transform.SetParent(null);
    }

    private Vector3 GetThrowPoint(Ray shotRay)
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(shotRay, out hitInfo, maxDistance))
        {
            return hitInfo.point;
        }
        else
        {
            return shotRay.origin + shotRay.direction * maxDistance;
        }
    }
}
