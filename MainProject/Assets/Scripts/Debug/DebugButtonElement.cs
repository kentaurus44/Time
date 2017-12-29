using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugButtonElement : MonoBehaviour
{
    [SerializeField]
    protected Button _button;

    [SerializeField]
    protected Image _image;

    [SerializeField]
    protected Text _ButtonTextField;

    private GameObject _target;

    protected void Awake()
    {
        _button.onClick.AddListener(OnButtonCB);
    }

    protected void OnDisable()
    {
        _image.color = Color.white;
    }

    public void UpdateButtonElement(GameObject target)
    {
        _ButtonTextField.text = target.name;
        _target = target;
    }

    protected void OnButtonCB()
    {
        _target.SetActive(!_target.activeSelf);
        _target.transform.SetAsLastSibling();

        if (_target.activeSelf)
        {
            _image.color = Color.green;
        }
        else
        {
            _image.color = Color.white;
        }
    }
}
