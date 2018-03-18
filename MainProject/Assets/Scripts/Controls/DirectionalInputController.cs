//
// Script name: DirectionalInputController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using UnityEngine.EventSystems;


public class DirectionalInputController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    #region Variables
    protected Vector3 m_CenterPosition;
    protected Vector3 m_TargetPosition;
    protected float m_Angle;

    [SerializeField]
	protected bool m_InitOnAwake = false;
	[SerializeField]
	protected RectTransform m_PanelRect;
	protected bool m_IsMoving = false;
	protected bool m_IsFingerDown = false;

	public float Angle
    {
        get { return m_Angle; }
    }
    #endregion

    #region Unity API
    protected virtual void Awake()
    {
        if (m_InitOnAwake)
        {
            Init();
        }
    }
    #endregion

    #region Public Methods
    public virtual void Init()
    {
		Vector3 position = CustomCamera.CameraManager.Instance.UICamera.WorldToScreenPoint(m_PanelRect.position);
		position.z = 0f;
		m_CenterPosition = position;
	}

	public void OnPointerDown(PointerEventData data)
	{
		m_IsFingerDown = true;
		m_IsMoving = true;
		OnDataSet(data);
	}

	public void OnDrag(PointerEventData data)
	{
		OnDataSet(data);
	}

	public void OnPointerUp(PointerEventData data)
	{
		m_IsFingerDown = false;
		m_IsMoving = false;
	}

	public void OnPointerEnter(PointerEventData data)
	{
		m_IsMoving = true;
		OnDataSet(data);
	}

	public void OnPointerExit(PointerEventData data)
	{
		m_IsMoving = false;
	}
	#endregion

	#region Protected Methods
	protected virtual void SetAngle()
    {
		m_TargetPosition.z = transform.position.z;

        Vector3 direction = m_TargetPosition - m_CenterPosition;

        // Vector3.Angle can only find 180 angles
        m_Angle = Vector3.Angle(Vector3.up, direction);

        // Checking for 360 degress
        if (m_CenterPosition.x > m_TargetPosition.x)
        {
            m_Angle = 360 - m_Angle;
        }
    }

	protected virtual void OnDataSet(PointerEventData data)
	{
		m_PanelRect.SetAsFirstSibling();
		m_TargetPosition = CustomCamera.CameraManager.Instance.UICamera.WorldToScreenPoint(data.position);
		SetAngle();
	}
	#endregion

	#region Private Methods
	#endregion
}