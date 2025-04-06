using UnityEngine;

public class RunawayAttackBehaviour : IBehaviour
{
	private const float _speed = 5f;

	public void Enter(Transform source, Transform target)
	{
		Vector3 direction = source.position - target.position;

		Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

		Vector3 normalizedDirection = xzDirection.normalized;

		source.transform.Translate(normalizedDirection * _speed * Time.deltaTime, Space.World);
	}

	public void Update(Transform source, Transform target)
	{
		Enter(source, target);
	}

	public void Disable()
	{

	}
}
