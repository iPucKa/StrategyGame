using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleDefaultBehaviour : IDefaultBehaviour
{
	public void Rest()
	{
		Debug.Log("Ничего не делаю, просто стою на месте");
	}
}
