using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableObject : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    public Vector3 defaultPosition;

    private void Start()
    {
        defaultPosition = transform.position;
    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    void OnMouseDrag()
    {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;

        transform.position = cursorPosition;
        Rigidbody rb = GetComponent<Rigidbody>();
    }

    private void OnMouseUp()
    {
        ResetToDefaultPosition();
    }

    public void ResetToDefaultPosition()
    {
        transform.position = defaultPosition;
    }
}
