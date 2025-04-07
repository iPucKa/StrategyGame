using UnityEngine;

public class SimpleAttackBehaviour : IBehaviour
{
	private const float _speed = 5f;

	private const float _minDistanceToTarget = 0.5f;

	private readonly Transform _source;
	private readonly Transform _target;

	public SimpleAttackBehaviour(Transform source, Transform target)
	{
		_source = source;
		_target = target;
	}

	public void Enter()
	{
		Vector3 direction = _target.position - _source.position;

		Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

		if (xzDirection.magnitude > _minDistanceToTarget)
		{
			Vector3 normalizedDirection = xzDirection.normalized;

			_source.transform.Translate(normalizedDirection * _speed * Time.deltaTime, Space.World);
		}
	}

	public void Update()
	{
		Enter();
	}

	public void Exit()
	{

	}
}
