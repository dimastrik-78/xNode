using UnityEngine;

namespace _Source.PersonNode
{
    public class God : BasePerson
    {
        [Input] public int Enter;

        [SerializeField] private string _personName;
        [SerializeField] private string _personText;
        [SerializeField] private Sprite _personSprite;

        public override string GetBackSwapTrigger()
        {
            return "Enter";
        }
		
        public override string GetString()
        {
            return $"Person/{_personName}/{_personText}";
        }

        public override Sprite GetSprite()
        {
            return _personSprite;
        }
    }
}