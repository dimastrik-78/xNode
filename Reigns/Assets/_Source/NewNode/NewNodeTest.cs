using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.NewNode
{
    
    public class NewNodeTest : ScriptableObject
    {
        [field: SerializeField] public NewNodeTest LastNode {get; private set;}
        [field: SerializeField] public List<NewNodeTest> NextNodes {get; private set;}
        [field: SerializeField] public Sprite IconCharacter {get; private set;}
        [field: SerializeField] public string NameCharacter {get; private set;}
    }
}