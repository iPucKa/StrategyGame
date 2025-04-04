using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private float _speed = 5;
	[SerializeField] private float _rotationSpeed = 800;

	private IDefaultBehaviour _defaultBehaviour;
	private IAttackBehaviour _attackBehaviour;

	public void Initialize(IDefaultBehaviour defaultBehaviour, IAttackBehaviour attackBehaviour)
	{
		_defaultBehaviour = defaultBehaviour;
		_attackBehaviour = attackBehaviour;
		//Debug.Log(_defaultBehaviour.ToString());
		//Debug.Log(_attackBehaviour.ToString());
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.TryGetComponent( out Character character))
		{
			Debug.Log("Персонаж зашел в зону аггра");
			_attackBehaviour.Attack();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent(out Character character))
		{
			Debug.Log("Персонаж вышел из зоны аггра");
			_defaultBehaviour.Rest();
		}
	}
}
