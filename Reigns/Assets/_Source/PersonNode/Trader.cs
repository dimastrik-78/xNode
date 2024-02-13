using UnityEngine;

namespace _Source.PersonNode
{
    public class Trader : BasePerson
    {
        [Input] public int Enter;

        [Output] public string Right;
        [Output] public string Left;

        [SerializeField] private string _personName;
        [SerializeField] private string _personText;
        [SerializeField] private Sprite _personSprite;

        public override string GetLeftSwapTrigger()
        {
            return "Right";
        }
        
        public override string GetRightSwapTrigger()
        {
            return "Left";
        }
        
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

        public override void ConsentEffect()
        {
            Debug.Log("Поднимается доверие короля, но падает экономика");
        }
        
        public override void EffectOnFailure()
        {
            Debug.Log("Отнимается доверие короля");
        }
    }
}