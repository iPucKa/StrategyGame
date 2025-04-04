using UnityEngine;

public class Rotator : MonoBehaviour
{
	public void RotateTo(Vector3 direction, float speedRotation)
	{
		if (direction == Vector3.zero)
			return;

		Quaternion lookRotation = Quaternion.LookRotation(direction);
		float step = speedRotation * Time.deltaTime;

		transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
	}
}
