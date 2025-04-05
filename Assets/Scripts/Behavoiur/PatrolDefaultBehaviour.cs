using System.Collections.Generic;
using UnityEngine;

public class PatrolDefaultBehaviour : IDefaultBehaviour
{
	private readonly List<Transform> _patrolPoints;
	private const float _speed = 10f;

	private Queue<Vector3> _targetsPositions;
	private Vector3 _currentTarget;

	private const float _minDistanceToTarget = 0.5f;

	public PatrolDefaultBehaviour(List<Transform> patrolPoints)
	{
		_patrolPoints = patrolPoints;
	}

	public void Relax(Transform source)
	{
		InitializeQueue();

		Vector3 direction = _currentTarget - source.position;

		if (direction.magnitude <= _minDistanceToTarget)
			SwitchTarget();

		Vector3 normalizedDirection = direction.normalized;

		source.Translate(normalizedDirection * _speed * Time.deltaTime, Space.World);
	}

	private void InitializeQueue()
	{
		if (_targetsPositions == null)
		{
			_targetsPositions = new Queue<Vector3>();

			foreach (Transform patrolPoint in _patrolPoints)
				_targetsPositions.Enqueue(patrolPoint.position);

			SwitchTarget();
		}
	}

	private void SwitchTarget()
	{
		_currentTarget = _targetsPositions.Dequeue();
		_targetsPositions.Enqueue(_currentTarget);
	}
}
