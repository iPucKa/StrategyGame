using UnityEngine;

public class IdleDefaultBehaviour : IBehaviour
{
	public void Enter(Transform source, Transform target)
	{
		//Debug.Log("������ �� �����, ������ ���� �� �����");		
	}

	public void Update(Transform source, Transform target)
	{
		Enter(source, target);
	}

	public void Disable()
	{

	}
}
