using UnityEngine;

public class SimpleAttackBehaviour : IAttackBehaviour
{
	private const float _speed = 5f;

	private const float _minDistanceToTarget = 0.5f;

	public void Attack(Transform source, Transform target)
	{
		Vector3 direction = target.position - source.position;

		Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

		if(xzDirection.magnitude > _minDistanceToTarget)
		{
			Vector3 normalizedDirection = xzDirection.normalized;

			source.transform.Translate(normalizedDirection * _speed * Time.deltaTime, Space.World);
		}		
	}
}
