////
//// Script name: ControllerVisuals.cs
////
////
//// Programmer: Kentaurus
////

//using UnityEngine;
//using System.Collections.Generic;
//using System.Collections;


//public class ControllerVisuals : Observer
//{
//    #region Variables
//    private static readonly Dictionary<PlayereStaticInputController.eDirection, Vector3> DIRECTION_CONVERT = new Dictionary<PlayereStaticInputController.eDirection, Vector3>()
//    {
//        { PlayereStaticInputController.eDirection.NORTH,         new Vector3(30f, 0f, 0f) },
//        { PlayereStaticInputController.eDirection.NORTH_EAST,    new Vector3(15f, 15f, 0f) },
//        { PlayereStaticInputController.eDirection.EAST,          new Vector3(0f, 30f, 0f) },
//        { PlayereStaticInputController.eDirection.SOUTH_EAST,    new Vector3(-15f, 15f, 0f) },
//        { PlayereStaticInputController.eDirection.SOUTH,         new Vector3(-30f, 0f, 0f) },
//        { PlayereStaticInputController.eDirection.SOUTH_WEST,    new Vector3(-15f, -15f, 0f) },
//        { PlayereStaticInputController.eDirection.WEST,          new Vector3(0f, -30f, 0f) },
//        { PlayereStaticInputController.eDirection.NORTH_WEST,    new Vector3(15f, -15f, 0f) }

//    };
//    #endregion

//    #region Unity API
//    #endregion

//    #region Public Methods
//    #endregion

//    #region Protected Methods
//    #endregion

//    #region Private Methods
//    private void SetRotation(PlayereStaticInputController.eDirection dir)
//    {
//        transform.localEulerAngles = DIRECTION_CONVERT[dir];
//    }

//    private void ResetVisuals()
//    {
//        transform.localEulerAngles = Vector3.zero;
//    }
//    #endregion

//    #region IObservable
//    public override void OnNotify(ISubject subject, params object[] args)
//    {
//        base.OnNotify(subject, args);
//        if (subject is PlayereStaticInputController)
//        {
//            if (args[0] is sNotification)
//            {
//                sNotification sNotify = args[0] as sNotification;
//                if (sNotify.key.ToString().CompareTo(PlayereStaticInputController.ON_ANGLE_SET) == 0)
//                {
//                    SetRotation((PlayereStaticInputController.eDirection)sNotify.args[0]);
//                }
//                else if (sNotify.key.ToString().CompareTo(PlayereStaticInputController.ON_TOUCH_ENDED) == 0)
//                {
//                    ResetVisuals();
//                }
//            }
//        }
//    }
//    #endregion
//}