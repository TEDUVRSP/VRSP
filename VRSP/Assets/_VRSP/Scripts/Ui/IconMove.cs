using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMove : MonoBehaviour
{
    private Vector3 _position;
    public Vector3 pushedPosition;
    
    private void Start()
    {
        _position = transform.localPosition;
    }
    
    public void MoveDown()
    {
        transform.localPosition = pushedPosition;
    }
    
    public void MoveUp()
    {
        transform.localPosition = _position;
    }
}
