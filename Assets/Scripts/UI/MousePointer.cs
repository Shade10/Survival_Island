using UnityEngine;
using System.Collections;

public class MousePointer : MonoBehaviour
{
    public RectTransform Pointer;
    public RectTransform Canvas;

	void Update ()
    {
        Pointer.anchoredPosition = new Vector2(Mathf.Lerp(0, Canvas.sizeDelta.x, Input.mousePosition.x / Screen.width),
                                               Mathf.Lerp(0, Canvas.sizeDelta.y, Input.mousePosition.y / Screen.height));
	}
}
