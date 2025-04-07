using UnityEngine;

public class DeathAttackBehaviour : IBehaviour
{
	private readonly ParticleSystem _deathEffect;

	private readonly Transform _source;

	public DeathAttackBehaviour(ParticleSystem deathEffect, Transform source)
	{
		_deathEffect = deathEffect;
		_source = source;
	}

	public void Enter()
	{
		_deathEffect.transform.position = _source.transform.position;

		_source.gameObject.SetActive(false);

		_deathEffect.Play();

		Debug.Log("Очень страшно! Я УМЕР!");
	}

	public void Update()
	{

	}

	public void Exit()
	{

	}
}
