using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class CameraController : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;

    void LateUpdate()
    {
        transform.position = _targetTransform.transform.position;
    }
}
