using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private MeshRenderer _renderer;
	[SerializeField] private Material _aggredMaterial;

	private IBehaviour _defenceBehaviour;
	private IBehaviour _attackBehaviour;
	private IBehaviour _currentBehaviour;

	private float _defaultScale;
	private float _aggredtScale;

	private bool _hasAggred;
	private Material _defaultMaterial;

	public void Initialize(IBehaviour defaultBehaviour, IBehaviour attackBehaviour)
	{
		_defenceBehaviour = defaultBehaviour;
		_attackBehaviour = attackBehaviour;
		_currentBehaviour = defaultBehaviour;
	}

	private void Awake()
	{
		_defaultScale = transform.localScale.y;
		_aggredtScale = _defaultScale * 1.2f;
		_defaultMaterial = _renderer.material;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Character>())
		{
			SwitchBehaviour(_attackBehaviour);

			_hasAggred = true;

			ChangeScale();
			ChangeMaterial();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Character>())
		{
			SwitchBehaviour(_defenceBehaviour);

			_hasAggred = false;

			ChangeScale();
			ChangeMaterial();
		}
	}

	private void OnDisable() => Destroy(gameObject);

	private void Update()
	{
		_currentBehaviour.Update();
	}

	private void SwitchBehaviour(IBehaviour behaviour)
	{
		_currentBehaviour.Exit();
		_currentBehaviour = behaviour;
		_currentBehaviour.Enter();
	}

	private void ChangeScale()
	{
		if (_hasAggred)
			transform.localScale = new Vector3(_aggredtScale, _aggredtScale, _aggredtScale);

		if (_hasAggred == false)
			if (transform.localScale.y != _defaultScale)
				transform.localScale = new Vector3(_defaultScale, _defaultScale, _defaultScale);
	}

	private void ChangeMaterial()
	{
		if (_hasAggred)
		{
			_renderer.material = _aggredMaterial;
			return;
		}

		if (_hasAggred == false)
			if (_renderer.material != _defaultMaterial)
				_renderer.material = _defaultMaterial;
	}
}
