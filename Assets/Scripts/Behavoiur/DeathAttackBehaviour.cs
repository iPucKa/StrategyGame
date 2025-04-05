using UnityEngine;

public class DeathAttackBehaviour : IAttackBehaviour
{
	private readonly ParticleSystem _deathEffect;

	public DeathAttackBehaviour(ParticleSystem deathEffect)
	{
		_deathEffect = deathEffect;
	}

	public void Attack(Transform source, Transform target)
	{
		_deathEffect.transform.position = source.transform.position;

		source.gameObject.SetActive(false);

		_deathEffect.Play();

		Debug.Log("Очень страшно! Я УМЕР!");
	}
}
