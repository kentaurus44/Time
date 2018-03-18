//
// Script name: InputController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;

public class CircleInputController : DirectionalInputController
{
    #region Variables

	[SerializeField] protected float m_Radius = 50f;

    private float m_Ratio;

	public float Ratio 
	{
		get { return m_Ratio; }
	}
    #endregion
    
    #region Unity API
    #endregion

    #region Public Methods

    #endregion

    #region Protected Methods
    protected override void SetAngle()
    {
        base.SetAngle();

        Vector3 direction = m_TargetPosition - m_CenterPosition;

        if (direction.magnitude > m_Radius)
        {
            m_TargetPosition = m_CenterPosition + direction.normalized * m_Radius;
        }

        m_Ratio = Mathf.Clamp01(direction.magnitude / m_Radius);
    }
    #endregion

    #region Private Methods

    #endregion
}