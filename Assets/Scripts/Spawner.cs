using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Enemy _enemyPrefab;
	[SerializeField] private List<SpawnPoint> _spawnPoints;

	[SerializeField] private ParticleSystem _deathEffectPrefab;

	[SerializeField] private List<Transform> _patrolPoints;

	[SerializeField] private Character _target;

	private void Awake()
	{
		foreach (SpawnPoint spawnPoint in _spawnPoints)
		{
			Enemy enemy = CreateEnemy(spawnPoint);

			enemy.Initialize(FindDefaultBehaviour(spawnPoint, enemy.transform), FindAttackBehaviour(spawnPoint, enemy.transform, _target.transform));
		}
	}

	private Enemy CreateEnemy(SpawnPoint spawnPoint) => Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);

	private ParticleSystem CreateDeathEffect() => Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);

	private IBehaviour FindDefaultBehaviour(SpawnPoint spawnPoint, Transform source)
	{
		EnumDefaultBehavour defaultBehavour = spawnPoint.DefaultBehavour;

		switch (defaultBehavour)
		{
			case EnumDefaultBehavour.Idle:
				return new IdleDefaultBehaviour();
			case EnumDefaultBehavour.Patrol:
				return new PatrolDefaultBehaviour(_patrolPoints, source);
			case EnumDefaultBehavour.WalkRandomly:
				return new RandomWalkDefaultBehaviour(source);
			default:
				return new IdleDefaultBehaviour();
		}
	}

	private IBehaviour FindAttackBehaviour(SpawnPoint spawnPoint, Transform source, Transform target)
	{
		EnumAttackBehaviour attackBehavour = spawnPoint.AttackBehaviour;

		switch (attackBehavour)
		{
			case EnumAttackBehaviour.RunAway:
				return new RunawayAttackBehaviour(source, target);
			case EnumAttackBehaviour.Attack:
				return new SimpleAttackBehaviour(source, target);
			case EnumAttackBehaviour.Dead:
				return new DeathAttackBehaviour(CreateDeathEffect(), source);
			default:
				return new SimpleAttackBehaviour(source, target);
		}
	}
}
