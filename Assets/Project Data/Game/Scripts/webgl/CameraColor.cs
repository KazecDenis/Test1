using System;
using System.Collections.Generic;
using UnityEngine;
using Watermelon.LevelSystem;

namespace webgl
{
    public class CameraColor : MonoBehaviour
    {
        private Camera _camera;
        
        [SerializeField] private List<Color> _colors = new List<Color>
        {
            new Color(255, 197, 154),
            new Color(169, 166, 255),
        };

        private void Awake()
        {
            _camera = Camera.main;
            LevelController.OnGameplayStart += ChangeColor;
        }

        private void ChangeColor()
        {
            var index = ActiveRoom.CurrentWorldIndex % 2 == 0 ? 0 : 1;
            _camera.backgroundColor = _colors[index];
        }
    }
}
