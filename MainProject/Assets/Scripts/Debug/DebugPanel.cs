using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugPanel : MonoBehaviour
{
    [SerializeField]
    protected GameObject[] _debugPanels;

    [SerializeField]
    protected GameObject[] _debugElements;

    [SerializeField]
    protected Transform _buttonAnchor;

    [SerializeField]
    protected DebugButtonElement _debugButton;

    [SerializeField]
    protected Button _debugShowButton;

    private List<DebugButtonElement> _debugButtons = new List<DebugButtonElement>();

    protected void Start()
    {
        InitPanels();
        EnabledElements(false);
        _debugShowButton.onClick.AddListener(DebugButtonCB);
        _debugShowButton.gameObject.SetActive(false);
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            _debugShowButton.gameObject.SetActive(!_debugShowButton.gameObject.activeSelf);
            EnabledElements(false);
        }
    }

    protected void InitPanels()
    {
        DebugButtonElement element = null;
        for (int i = 0; i < _debugPanels.Length; ++i)
        {
            _debugPanels[i].SetActive(false);
            element = Instantiate<DebugButtonElement>(_debugButton, _buttonAnchor, true);
            element.UpdateButtonElement(_debugPanels[i]);
            element.gameObject.SetActive(true);
            _debugButtons.Add(element);
        }
    }

    protected void DebugButtonCB()
    {
        bool activate = !_debugElements[0].activeSelf;
        EnabledElements(activate);
    }

    protected void EnabledElements(bool enabled)
    {
        for (int i = 0; i < _debugElements.Length; ++i)
        {
            _debugElements[i].SetActive(enabled);
        }
    }
}
