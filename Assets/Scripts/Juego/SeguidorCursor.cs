using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguidorCursor : MonoBehaviour
{
    void Update()
    {
        Vector2 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GetComponent<Rigidbody2D>().MovePosition(mousePos);
    }
}
