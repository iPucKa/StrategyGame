using UnityEngine;

public class RandomWalkDefaultBehaviour : IBehaviour
{
	private const int _xRange = 4;
	private const float _zRange = 4f;

	private const float _speed = 2f;

	private Vector3 _currentTargetPosition;

	private float _time;

	private readonly Transform _source;

	public RandomWalkDefaultBehaviour(Transform source)
	{
		_source = source;
	}

	public void Enter()
	{
		Update();
	}

	public void Update()
	{
		if (_currentTargetPosition == Vector3.zero)
			_currentTargetPosition = GetRandomPosition(_source);

		Vector3 direction = (_currentTargetPosition - _source.position).normalized;

		if (_time < 1)
			_source.Translate(direction * _speed * Time.deltaTime, Space.World);

		_time += Time.deltaTime;

		if (_time >= 1)
		{
			_currentTargetPosition = Vector3.zero;
			_time = 0;
		}
	}

	public void Exit()
	{
		_currentTargetPosition = Vector3.zero;
		_time = 0;
	}

	private Vector3 GetRandomPosition(Transform source)
	{
		float xPosition = source.position.x + Random.Range(-_xRange, _xRange);
		float zPosition = source.position.z + Random.Range(-_zRange, _zRange);

		return new Vector3(xPosition, 0f, zPosition);
	}
}
