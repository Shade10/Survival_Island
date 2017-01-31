using UnityEngine;
using System.Collections;

public class IKPoint : MonoBehaviour
{
    public MeshRenderer Renderer;
    private void Start()
    {
        if(Application.isPlaying)
        {
            Renderer.enabled =false;
        }
    }
}
