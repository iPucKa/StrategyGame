using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private EnumDefaultBehavour _defaultBehaviour;
    [SerializeField] private EnumAttackBehaviour _attackBehaviour;

    public EnumDefaultBehavour DefaultBehavour => _defaultBehaviour;

	public EnumAttackBehaviour AttackBehaviour => _attackBehaviour;    	
}
