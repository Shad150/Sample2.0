using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShapeShifterBehaviour : MonoBehaviour
{
    private float _x;
    private float _y;
    private float _z;

    void Start()
    {
        Time.timeScale = 1f;
    }

    void Update()
    {
        _x = Random.value;
        _y = Random.value;
        _z = Random.value;
        Vector3 _rotation = new Vector3(_x, _y, _z) * 10;
        transform.Rotate(_rotation * Time.deltaTime);
    }
}
