using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Tutor
{
    public class NodeParser : MonoBehaviour
    {
        [SerializeField] private DialogueGraph _graph;
        private Coroutine _parser;

        public Text speaker;
        public Text dialogue;
        // public Image SpeakerImage;

        private void Start()
        {
            foreach (BaseNode basePerson in _graph.nodes)
            {
                if (basePerson.GetString() == "Start")
                {
                    _graph._current = basePerson;
                    // break;
                }
            }
            
            _parser = StartCoroutine(ParseNode());
        }
        
        private IEnumerator ParseNode()
        {
            BaseNode b = _graph._current;
            Debug.Log(b.GetString());
            string data = b.GetString();
            string[] dataParts = data.Split('/');

            if (dataParts[0] == "Start")
            {
                NextNode("exit");
            }
            
            if (dataParts[0] == "DialogueNode")
            {
                speaker.text = dataParts[1];
                dialogue.text = dataParts[2];
                // SpeakerImage.sprite = b.GetSprite();

                yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
                yield return new WaitUntil(() => Input.GetMouseButtonUp(0));
                
                NextNode("exit");
            }
        }

        public void NextNode(string fieldName)
        {
            if (_parser is not null)
            {
                StopCoroutine(_parser);
                _parser = null;
            }

            foreach (var p in _graph._current.Ports)
            {
                Debug.Log(p.fieldName);
                Debug.Log(fieldName);
                if (p.fieldName == fieldName)
                {
                    Debug.Log(_graph._current.GetString());
                    _graph._current = p.Connection.node as BaseNode;
                    break;
                }
            }
            
            _parser = StartCoroutine(ParseNode());
        }
    }
}