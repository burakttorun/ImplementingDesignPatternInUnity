using System.Collections;
using System.Collections.Generic;
using ThePrototype.Scripts.Command;
using UnityEngine;

namespace ThePrototype.Scripts.Command
{
    public class PlaceCubeCommand : ICommand
    {
        private Vector3 _position;
        private Color _color;
        private Transform _cube;

        public PlaceCubeCommand(Vector3 position, Color color, Transform cube)
        {
            _position = position;
            _color = color;
            _cube = cube;
        }

        public void Execute()
        {
            MethodManager.PlaceCube(_position, _color, _cube);
        }

        public void Undo()
        {
            MethodManager.RemoveCube(_position, _color);
        }

        public override string ToString()
        {
            return "PlaceCube\t" + _position.x + ":"
                   + _position.y + ":"
                   + _position.z + ":"
                   + "\t" + "Color: "
                   + _color.r + ":"
                   + _color.g + ":"
                   + _color.b;
        }
    }
}