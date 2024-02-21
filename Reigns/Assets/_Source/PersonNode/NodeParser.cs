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
        [SerializeField] private Text _reputationText;
        [SerializeField] private Text _moneyText;
        [SerializeField] private Text _attitudePeopleText;
        [SerializeField] private Text _beliefText;
        [SerializeField] private Image _speakerImage;
        [SerializeField] private KeyCode _leftSwap;
        [SerializeField] private KeyCode _rightSwap;
        [SerializeField] private KeyCode _backSwap;

        private IEnumerator _parser;

        private int _reputation = 50;
        private int _money = 50;
        private int _attitudePeople = 50;
        private int _belief = 50;
        private bool _isConsent;

        private const string START_NODE_TEXT = "Exit";
        private const string PERSON_TEXT = "Person";

        private void Start()
        {
            foreach (BasePerson basePerson in _graph.nodes)
            {
                if (basePerson.GetString() == START_NODE_TEXT)
                {
                    _graph._current = basePerson;
                    break;
                }
            }

            _parser = ParseNode();
            StartCoroutine(_parser);
        }

        private void SetParameters(BasePerson basePerson, string[] dataParts)
        {
            _speaker.text = dataParts[1];
            _dialogue.text = dataParts[2];
            _speakerImage.sprite = basePerson.GetSprite();
        }

        private void SelectionResult(BasePerson basePerson, bool isConsent, bool isBack)
        {
            int[] parameters = isConsent ? basePerson.ConsentEffect() : basePerson.EffectOnFailure();
            int coefficient = isBack ? -1 : 1;
            
            _reputation += parameters[0] * coefficient;
            _money += parameters[1] * coefficient;
            _attitudePeople += parameters[2] * coefficient;
            _belief += parameters[3] * coefficient;
            
            _reputationText.text = $"Репутация {_reputation}";
            _moneyText.text = $"Деньги {_money}";
            _attitudePeopleText.text = $"Отношение народа  {_attitudePeople}";
            _beliefText.text = $"Вера {_belief}";
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
                SetParameters(basePerson, dataParts);
                
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
                    _isConsent = false;
                    SelectionResult(basePerson, _isConsent, false);
                    ChangeNode(basePerson.GetLeftSwapTrigger());
                }
                else if (key == _rightSwap)
                {
                    _isConsent = true;
                    SelectionResult(basePerson, _isConsent, false);
                    ChangeNode(basePerson.GetRightSwapTrigger());
                }
                else if (key == _backSwap)
                {
                    ChangeNode(basePerson.GetBackSwapTrigger(), true);
                }
            }
        }

        private void ChangeNode(string fieldName, bool isBack = false)
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
            
            if (isBack)
            {
                SelectionResult(_graph._current, _isConsent, true);
            }
            _parser = ParseNode();
            StartCoroutine(_parser);
        }
    }
}