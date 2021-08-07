using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CirclesController : MonoBehaviour
{
  
    private int circles;

    public delegate void countCircles();
    public event countCircles eventCircles;

    private void Update()
    {
        circles = gameObject.transform.childCount;
        if (circles == 0)
        {
            eventCircles?.Invoke();
        }
    }
}
