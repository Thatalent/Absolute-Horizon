using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


    public interface IFloatingTextPositioner
    {
    int GetPosition(ref Vector2 position, GUIContent content, Vector2 size);
    }

