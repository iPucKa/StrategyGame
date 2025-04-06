using UnityEngine;

public interface IBehaviour
{
	void Enter(Transform source, Transform target);

	void Update(Transform source, Transform target);

	void Disable();
}
