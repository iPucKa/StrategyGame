using UnityEngine;

public class Mover : MonoBehaviour
{
	public void MoveTo(Vector3 direction, float speedMoving)
	{
		transform.Translate(direction * speedMoving * Time.deltaTime, Space.World);

		Debug.DrawRay(transform.position, direction, Color.red);
	}
}
