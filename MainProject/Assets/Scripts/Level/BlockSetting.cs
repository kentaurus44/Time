using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSetting : Track
{
    [Header("Walls")]
    [SerializeField]
    protected Transform _leftWall;
    [SerializeField]
    protected Transform _rightWall;
    [SerializeField]
    protected Transform _botWall;

    [Header("Visuals")]
    [SerializeField]
    protected Transform _visual;
    [SerializeField]
    protected Vector3 _size;

#if UNITY_EDITOR
    public void Resize()
    {
        _visual.localScale = _size;

        Vector3 rightPosition = new Vector3(_size.x / 2f - 0.5f, 0f);
        Vector3 leftPosition = new Vector3(-_size.x / 2f + 0.5f, 0f);
        Vector3 topPosition = new Vector3(0f, _size.y / 2f);
        Vector3 botPosition = new Vector3(0f, -_size.y / 2f + 0.5f);

        if (_leftWall != null)
        {
            _leftWall.localPosition = leftPosition;
            BoxCollider2D collider = _leftWall.GetComponent<BoxCollider2D>();
            Vector2 size = collider.size;
            size.y = _size.y;
            size.x = 1f;
            collider.size = size;
        }

        if (_rightWall != null)
        {
            _rightWall.localPosition = rightPosition;
            BoxCollider2D collider = _rightWall.GetComponent<BoxCollider2D>();
            Vector2 size = collider.size;
            size.y = _size.y;
            size.x = 1f;
            collider.size = size;
        }

        _begin.localPosition = leftPosition + topPosition;
        _end.localPosition = rightPosition + topPosition;

        if (_botWall != null)
        {
            _botWall.localPosition = botPosition;
            BoxCollider2D collider = _botWall.GetComponent<BoxCollider2D>();

            Vector2 size = collider.size;
            size.x = _size.x;
            size.y = 1f;
            collider.size = size;
        }

    }
#endif
}
