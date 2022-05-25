using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public bool CanPlay { get; set; }
    private bool isHolding;

    [SerializeField] private float dragMultiplier;
    private float _previousMousePosX;
    private float _xPosition;
    private float _maxPosition = 10f;

    private Player player => Player.Instance;
    private PlayerMovement movement => player.PlayerMovement;

    private void Update()
    {
        if (!CanPlay) return;

        if (Input.GetMouseButtonDown(0))
        {
            isHolding = true;
            _previousMousePosX = Input.mousePosition.x;

        }

        if (Input.GetMouseButtonUp(0))
        {
            isHolding = false;

            if (!player.IsFinished)
            {
                Vector3 velocity = movement.Rigidbody.velocity;
                velocity.x = 0;
                movement.Rigidbody.velocity = velocity;
            }
        }
    }

    private void FixedUpdate()
    {
        Drag();
    }

    private void Drag()
    {
        if (!CanPlay) return;
        if (!isHolding) return;

        float delta = Input.mousePosition.x - _previousMousePosX;
        _previousMousePosX = Input.mousePosition.x;
        _xPosition += delta * dragMultiplier / Screen.width;
        _xPosition = Mathf.Clamp(_xPosition, -_maxPosition, _maxPosition);
        transform.position = new Vector3(_xPosition, transform.position.y, transform.position.z);
    }
}

