//
// Script name: StaticInputController.cs
//
//
// Programmer: Kentaurus
//

using UnityEngine;
using System.Collections;


public class StaticInputController : DirectionalInputController
{
    #region Variables
    #endregion

    #region Unity API
    #endregion

    #region Public Methods
    public override void Init()
    {
        base.Init();
        m_CenterPosition = transform.position;
    }
    #endregion

    #region Protected Methods
    #endregion

    #region Private Methods
    #endregion
}