using System;
using UnityEngine;

namespace _Source.NewNode
{
    public class WorkWithNode : MonoBehaviour
    {
        [SerializeField] private NewNodeTest startNode;

        private NewNodeTest currentNode;

        private void Start()
        {
            if (currentNode == null)
            {
                currentNode = startNode;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextNode();
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                PreviousNode();
            }
        }

        private void NextNode() // Т.к как у нас будет UI можно будет к кнопкам определять какой int они передают для запуска нужной ноды из листа
        {
            currentNode = currentNode.NextNodes[0];
        }

        private void PreviousNode() // Просто вызываем прошлую ноду
        {
            currentNode = currentNode.LastNode;
        }

        private void UpdateUI()
        {
            // Тут можно обновлять UI
            // Лучше вынести в отдельный класс UI и по ивенту вызывать его обновление
        }
    }
}