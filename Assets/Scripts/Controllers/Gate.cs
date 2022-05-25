using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum Math
{
    addition,
    multiplication
}
public class Gate : MonoBehaviour
{
    public int _value;

    [SerializeField] private Math _math;
    [SerializeField] private TMP_Text _valueText;

    [SerializeField] private Renderer _transparentRenderer;
    [SerializeField] private Material _gateBlue;
    [SerializeField] private Material _gateRed;

    private void OnValidate()
    {
        UpdateVisual();
    }

    void UpdateVisual()
    {
        if (_math == Math.addition)
        {
            string prefix = "";
            if (_value > 0)
            {
                SetBlue();
                prefix = "+";
            }
            else if (_value == 0)
            {
                SetBlue();
            }
            else
            {
                SetRed();
            }
            _valueText.text = prefix + _value.ToString();
        }

        if (_math == Math.multiplication)
        {
            SetBlue();
            _valueText.text = "x2";
        }

    }

    [ContextMenu("SetBlue")]
    private void SetBlue()
    {
        _transparentRenderer.material = _gateBlue;
    }

    [ContextMenu("SetRed")]
    private void SetRed()
    {
        _transparentRenderer.material = _gateRed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            BallController ballController = other.attachedRigidbody.GetComponent<BallController>();

            if (ballController)
            {
                if (_math == Math.multiplication)
                {
                    Debug.Log("x2");
                    ballController.Multiple();
                    Destroy(gameObject);
                }

                if (_math == Math.addition)
                {
                    Debug.Log("addition");
                    ballController.Addition(_value);
                    Destroy(gameObject);
                }
            }
        }
    }
}
