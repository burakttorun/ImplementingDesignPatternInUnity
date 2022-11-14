using System;
using System.Collections;
using System.Collections.Generic;
using ThePrototype.Scripts.Command;
using UnityEngine;

namespace ThePrototype.Scripts.Command
{
    public class CommandInvoker : MonoBehaviour
    {
        private static Queue<ICommand> _commandBuffer;
        private static List<ICommand> _commandHistory;
        private static int _counter;

        private void Awake()
        {
            _commandBuffer = new Queue<ICommand>();
            _commandHistory = new List<ICommand>();
        }

        public static void AddCommand(ICommand command)
        {
            _commandBuffer.Enqueue(command);
            while (_commandHistory.Count > _counter)
            {
                _commandHistory.RemoveAt(_counter);
            }
        }

        private void Update()
        {
            if (_commandBuffer.Count > 0)
            {
                ICommand command = _commandBuffer.Dequeue();
                command.Execute();
                _commandHistory.Add(command);
                _counter++;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Z))
                {
                    if (_counter > 0)
                    {
                        _counter--;
                        _commandHistory[_counter].Undo();
                    }
                }
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    if (_counter < _commandHistory.Count)
                    {
                        _commandHistory[_counter].Execute();
                        _counter++;
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                ExportLog();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                var cubes = GameObject.FindGameObjectsWithTag("Cube");
                for (int i = 0; i < cubes.Length; i++)
                {
                    cubes[i].SetActive(false);
                }
                
            }
            
        }

        static void ExportLog()
        {
            List<string> lines = new List<string>();
            for (int i = 0; i < _commandHistory.Count; i++)
            {
                lines.Add(_commandHistory[i].ToString());
            }
            System.IO.File.WriteAllLines(Application.dataPath + "/commandLog.txt", lines);
        }
    }
}