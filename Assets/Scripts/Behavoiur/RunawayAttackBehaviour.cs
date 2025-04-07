using UnityEngine;

public class RunawayAttackBehaviour : IBehaviour
{
	private const float _speed = 5f;

	private readonly Transform _source;
	private readonly Transform _target;

	public RunawayAttackBehaviour(Transform source, Transform target)
	{
		_source = source;
		_target = target;
	}

	public void Enter()
	{
		Vector3 direction = _source.position - _target.position;

		Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

		Vector3 normalizedDirection = xzDirection.normalized;

		_source.transform.Translate(normalizedDirection * _speed * Time.deltaTime, Space.World);
	}

	public void Update()
	{
		Enter();
	}

	public void Exit()
	{

	}
}
