using UnityEngine;
using System;
using System.Collections;
  
[RequireComponent(typeof(Animator))]
[ExecuteInEditMode]
public class IK : MonoBehaviour 
{
	public Animator Avatar;

    public Transform throwPoint1;
    public Transform throwPoint2;
	public Transform rightHandObj = null;
	public Transform lookAtObj = null;
	
	public float rightHandWeightPosition = 1;
	public float rightHandWeightRotation = 1;
    
	void OnAnimatorIK(int layerIndex)
	{		
		if(Avatar)
		{
			Avatar.SetIKPositionWeight(AvatarIKGoal.RightHand,rightHandWeightPosition);
			Avatar.SetIKRotationWeight(AvatarIKGoal.RightHand,rightHandWeightRotation);
				
			Avatar.SetLookAtWeight(1.0f,0.3f,0.6f,1.0f,0.5f);
				
			if(rightHandObj != null)
			{
				Avatar.SetIKPosition(AvatarIKGoal.RightHand,rightHandObj.position);
				Avatar.SetIKRotation(AvatarIKGoal.RightHand,rightHandObj.rotation);
			}				
				
			if(lookAtObj != null)
			{
				Avatar.SetLookAtPosition(lookAtObj.position);
			}				
		}
	}  
}
