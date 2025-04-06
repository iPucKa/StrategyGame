using UnityEngine;

public class RandomWalkDefaultBehaviour : IBehaviour
{
	private const int _xRange = 4;
	private const float _zRange = 4f;

	private const float _speed = 2f;

	private Vector3 _currentTargetPosition;

	private float _time;

	public void Enter(Transform source, Transform target)
	{
		if (_currentTargetPosition == Vector3.zero)
			GetNewPosition(source);

		Vector3 direction = (_currentTargetPosition - source.position).normalized;

		if (_time < 1)
			source.Translate(direction * _speed * Time.deltaTime, Space.World);
	}

	public void Update(Transform source, Transform target)
	{
		Enter(source, target);

		_time += Time.deltaTime;

		if (_time >= 1)
		{
			_currentTargetPosition = Vector3.zero;
			_time = 0;
		}
	}

	public void Disable()
	{
		_currentTargetPosition = Vector3.zero;
		_time = 0;
	}

	private void GetNewPosition(Transform source) => _currentTargetPosition = GetRandomPoint(source);

	private Vector3 GetRandomPoint(Transform source)
	{
		float xPosition = source.position.x + Random.Range(-_xRange, _xRange);
		float zPosition = source.position.z + Random.Range(-_zRange, _zRange);

		return new Vector3(xPosition, 0f, zPosition);
	}
}
