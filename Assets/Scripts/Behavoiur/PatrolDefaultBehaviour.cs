using System.Collections.Generic;
using UnityEngine;

public class PatrolDefaultBehaviour : IBehaviour
{
	private readonly List<Transform> _patrolPoints;
	private const float _speed = 10f;

	private Queue<Vector3> _targetsPositions;
	private Vector3 _currentTarget;

	private const float _minDistanceToTarget = 0.5f;

	private readonly Transform _source;

	public PatrolDefaultBehaviour(List<Transform> patrolPoints, Transform source)
	{
		_patrolPoints = patrolPoints;
		_source = source;
	}

	public void Enter()
	{
		Update();
	}

	private void InitializeQueue()
	{
		_targetsPositions = new Queue<Vector3>();

		foreach (Transform patrolPoint in _patrolPoints)
			_targetsPositions.Enqueue(patrolPoint.position);

		SwitchTarget();
	}

	private void SwitchTarget()
	{
		_currentTarget = _targetsPositions.Dequeue();
		_targetsPositions.Enqueue(_currentTarget);
	}

	public void Update()
	{
		if (_targetsPositions == null)
			InitializeQueue();

		Vector3 direction = _currentTarget - _source.position;

		if (direction.magnitude <= _minDistanceToTarget)
			SwitchTarget();

		Vector3 normalizedDirection = direction.normalized;

		_source.Translate(normalizedDirection * _speed * Time.deltaTime, Space.World);
	}

	public void Exit()
	{

	}
}
