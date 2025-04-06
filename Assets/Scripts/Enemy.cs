using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] private MeshRenderer _renderer;
	[SerializeField] private Material _aggredMaterial;

	private IBehaviour _defaultBehaviour;
	private IBehaviour _attackBehaviour;

	private float _defaultScale;
	private float _aggrotScale;

	private bool _hasAggred;
	private Material _defaultMaterial;

	public void Initialize(IBehaviour defaultBehaviour, IBehaviour attackBehaviour)
	{
		_defaultBehaviour = defaultBehaviour;
		_attackBehaviour = attackBehaviour;
	}

	private void Awake()
	{
		_defaultScale = transform.localScale.y;
		_aggrotScale = _defaultScale * 1.2f;
		_defaultMaterial = _renderer.material;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out Character character))
		{
			_attackBehaviour.Enter(transform, character.transform);
			_defaultBehaviour.Disable();

			_hasAggred = true;

			ChangeScale();
			ChangeMaterial();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.TryGetComponent(out Character character))
			_attackBehaviour.Update(transform, character.transform);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.TryGetComponent(out Character character))
		{
			_defaultBehaviour.Enter(transform, character.transform);
			_attackBehaviour.Disable();

			_hasAggred = false;

			ChangeScale();
			ChangeMaterial();
		}
	}

	private void OnDisable()
	{
		Destroy(gameObject);
	}

	private void Update()
	{
		if (_hasAggred == false)
			_defaultBehaviour.Update(transform, transform);
	}

	private void ChangeScale()
	{
		if (_hasAggred)
			transform.localScale = new Vector3(_aggrotScale, _aggrotScale, _aggrotScale);

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
