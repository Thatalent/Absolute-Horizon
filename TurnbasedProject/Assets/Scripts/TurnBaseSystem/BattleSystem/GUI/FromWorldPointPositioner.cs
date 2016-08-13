using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FromWorldPointPositioner : IFloatingTextPositioner
{
    private readonly Camera mainCamera;
    private readonly float _speed;
    private float _timeToLive;
    private readonly Vector3 _worldPosition;
    private float _yOffset;

    public FromWorldPointPositioner(Camera camera, Vector3 worldPosition,float timeToLive, float speed)
    {
        mainCamera = camera;
        _worldPosition = worldPosition;
        _timeToLive = timeToLive;
        _speed = speed;

    }
    public int GetPosition(ref Vector2 position, GUIContent content, Vector2 size)
    {
        if((_timeToLive -= Time.deltaTime) <= 0)
        {

            return 2;
        }

        var screenPosition = mainCamera.WorldToScreenPoint(_worldPosition);
        position.x = screenPosition.x - (size.x / 2);
        position.y = Screen.height - screenPosition.y - _yOffset;

        _yOffset += Time.deltaTime + _speed;
        return 1;
    }
}
