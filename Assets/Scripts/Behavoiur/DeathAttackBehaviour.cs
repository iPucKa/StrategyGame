using UnityEngine;

public class DeathAttackBehaviour : IBehaviour
{
	private readonly ParticleSystem _deathEffect;

	public DeathAttackBehaviour(ParticleSystem deathEffect)
	{
		_deathEffect = deathEffect;
	}

	public void Enter(Transform source, Transform target)
	{
		_deathEffect.transform.position = source.transform.position;

		source.gameObject.SetActive(false);

		_deathEffect.Play();

		Debug.Log("Очень страшно! Я УМЕР!");
	}

	public void Update(Transform source, Transform target)
	{

	}

	public void Disable()
	{

	}
}
