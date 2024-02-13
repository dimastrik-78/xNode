using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.PersonNode
{
    public class NodeParser : MonoBehaviour
    {
        [SerializeField] private PersonGraph _graph;
        [SerializeField] private Text _speaker;
        [SerializeField] private Text _dialogue;
        [SerializeField] private Image _speakerImage;
        [SerializeField] private KeyCode _leftSwap;
        [SerializeField] private KeyCode _rightSwap;
        [SerializeField] private KeyCode _backSwap;

        private Coroutine _parser;

        private const string START_NODE_TEXT = "Exit";
        private const string PERSON_TEXT = "Person";

        private void Start()
        {
            foreach (BasePerson basePerson in _graph.nodes)
            {
                if (basePerson.GetString() == START_NODE_TEXT)
                {
                    _graph._current = basePerson;
                    // break;
                }
            }
            
            _parser = StartCoroutine(ParseNode());
        }
        
        private IEnumerator ParseNode()
        {
            BasePerson basePerson = _graph._current;
            string data = basePerson.GetString();
            string[] dataParts = data.Split('/');
            
            if (dataParts[0] == START_NODE_TEXT)
            {
                ChangeNode(_graph._current.GetString());
            }
            
            if (dataParts[0] == PERSON_TEXT)
            {
                _speaker.text = dataParts[1];
                _dialogue.text = dataParts[2];
                // _speakerImage.sprite = basePerson.GetSprite();
                
                KeyCode key = KeyCode.A;
                yield return new WaitUntil(() =>
                {
                    if (Input.GetKeyDown(_leftSwap))
                    {
                        key = _leftSwap;
                        return true;
                    }
                    
                    if (Input.GetKeyDown(_rightSwap))
                    {
                        key = _rightSwap;
                        return true;
                    }
                    
                    if (Input.GetKeyDown(_backSwap))
                    {
                        key = _backSwap;
                        return true;
                    }
                
                    return false;
                });
                yield return new WaitUntil(() => Input.GetKeyUp(key));
                    
                if (key == _leftSwap)
                {
                    ChangeNode(basePerson.GetLeftSwapTrigger());
                }
                else if (key == _rightSwap)
                {
                    ChangeNode(basePerson.GetRightSwapTrigger());
                }
                else if (key == _backSwap)
                {
                    ChangeNode(basePerson.GetBackSwapTrigger());
                }
            }
        }

        private void ChangeNode(string fieldName)
        {
            if (_parser is not null)
            {
                StopCoroutine(_parser);
                _parser = null;
            }
            
            foreach (var port in _graph._current.Ports)
            {
                if (port.fieldName == fieldName)
                {
                    _graph._current = port.Connection.node as BasePerson;
                    break;
                }
            }
            
            _parser = StartCoroutine(ParseNode());
        }
    }
}