using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAttackBehaviour : IAttackBehaviour
{
	public void Attack()
	{
		Debug.Log("Очень страшно! Я УМЕР!");		
	}
}
