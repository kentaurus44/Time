using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class FlowLoadingScreen : MonoBehaviour
{

	[SerializeField]
	private float _moveTime = 0.5f;
	[SerializeField]
	private float _backgroundFadeTime = 0.1f;
	[SerializeField]
	private float _minLength = 1f;
	[SerializeField]
	private Image _background;

	[SerializeField]
	private GameObject _object;

	[SerializeField]
	private Color _fadeInColor;
	[SerializeField]
	private Color _fadeOutColor;

	[SerializeField]
	private Transform _initialPosition;
	[SerializeField]
	private Transform _finalPosition;

	private Sequence _sequence = null;
	private bool _isLoadingScreenOpen = false;

	public bool IsLoadingScreeenOpen { get { return _isLoadingScreenOpen; } }
	public bool IsTransitioning { get { return _sequence != null; } }

	public void Begin()
	{
		gameObject.SetActive(true);
		_object.transform.position = _initialPosition.position;
		_sequence = DOTween.Sequence();
		_isLoadingScreenOpen = true;
		_sequence.Append(_background.DOColor(_fadeInColor, _backgroundFadeTime));
		_sequence.Append(DOTween.To((x) => Move(x), 0f, 0.5f, _moveTime));
		_sequence.OnComplete(() => { _sequence = null; });
	}

	public void End()
	{
		_sequence = DOTween.Sequence();
		TweenCallback callback = () => {
			_isLoadingScreenOpen = false;
			gameObject.SetActive(false);
		};

		_sequence.Append(DOTween.To((x) => Move(x), 0.5f, 1f, _moveTime).SetDelay(_minLength));
		_sequence.Append(_background.DOColor(_fadeOutColor, _backgroundFadeTime).OnComplete(callback));
	}

	private void Move(float value)
	{
		_object.transform.position = Vector3.Lerp(_initialPosition.position, _finalPosition.position, value);
	}
}
