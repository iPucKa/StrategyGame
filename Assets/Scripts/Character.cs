using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	private string _horizontalAxisName = "Horizontal";
	private string _verticalAxisName = "Vertical";

	private float _xInput;
	private float _yInput;

	private float _deadInputZone = 0.1f;

	[SerializeField] private float _moveSpeed = 10;
	[SerializeField] private float _rotateSpeed = 500;

	private Mover _mover;
	private Rotator _rotator;

	private void Awake()
	{
		_mover = GetComponent<Mover>();
		_rotator = GetComponent<Rotator>();
	}

	private void Update()
	{
		_xInput = Input.GetAxisRaw(_horizontalAxisName);
		_yInput = Input.GetAxisRaw(_verticalAxisName);
	}

	private void FixedUpdate()
	{
		Vector3 input = new Vector3(_xInput, 0, _yInput);
		Vector3 normalizedInput = input.normalized;

		if (input.magnitude <= _deadInputZone)
			return;

		_rotator.RotateTo(normalizedInput, _rotateSpeed);
		_mover.MoveTo(normalizedInput, _moveSpeed);
	}
}
