using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] private Enemy _enemyPrefab;
	[SerializeField] private List<SpawnPoint> _spawnPoints;

	private void Awake()
	{
		foreach (SpawnPoint spawnPoint in _spawnPoints)
		{
			Enemy enemy = CreateEnemy(spawnPoint);
			enemy.Initialize(FindDefaultBehaviour(spawnPoint), FindAttackBehaviour(spawnPoint));
		}
	}

	private Enemy CreateEnemy(SpawnPoint spawnPoint)
	{
		Enemy enemy = Instantiate(_enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
		return enemy;
	}

	private void Update()
	{
		
	}

	private IDefaultBehaviour FindDefaultBehaviour(SpawnPoint spawnPoint)
	{
		EnumDefaultBehavour defaultBehavour = spawnPoint.DefaultBehavour;

		switch (defaultBehavour)
		{
			case EnumDefaultBehavour.Idle:
				return new IdleDefaultBehaviour();
			case EnumDefaultBehavour.Patrol:
				return new PatrolDefaultBehaviour();
			case EnumDefaultBehavour.WalkRandomly:
				return new RandomWalkDefaultBehaviour();
			default:
				return new IdleDefaultBehaviour();
		}
	}

	private IAttackBehaviour FindAttackBehaviour(SpawnPoint spawnPoint)
	{
		EnumAttackBehaviour attackBehavour = spawnPoint.AttackBehaviour;

		switch (attackBehavour)
		{
			case EnumAttackBehaviour.RunAway:
				return new RunawayAttackBehaviour();
			case EnumAttackBehaviour.Attack:
				return new SimpleAttackBehaviour();
			case EnumAttackBehaviour.Dead:
				return new DeathAttackBehaviour();
			default:
				return new SimpleAttackBehaviour();
		}
	}
}
