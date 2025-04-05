using UnityEngine;

public class RunawayAttackBehaviour : IAttackBehaviour
{
	private const float _speed = 5f;

	public void Attack(Transform source, Transform target)
	{
		Vector3 direction = source.position - target.position;

		Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

		Vector3 normalizedDirection = xzDirection.normalized;

		source.transform.Translate(normalizedDirection * _speed * Time.deltaTime, Space.World);
	}
}
