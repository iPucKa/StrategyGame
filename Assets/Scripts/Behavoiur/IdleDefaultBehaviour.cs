public class IdleDefaultBehaviour : IBehaviour
{
	public void Enter()
	{
		//Debug.Log("Ничего не делаю, просто стою на месте");		
	}

	public void Update()
	{
		Enter();
	}

	public void Exit()
	{

	}
}
