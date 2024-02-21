using UnityEngine;
using XNode;

namespace _Source.PersonNode
{
    public class BasePerson : Node
    {
        public virtual string GetLeftSwapTrigger()
        {
            return default;
        }
        
        public virtual string GetRightSwapTrigger()
        {
            return default;
        }
        
        public virtual string GetBackSwapTrigger()
        {
            return default;
        }
        
        public virtual string GetString()
        {
            return default;
        }

        public virtual Sprite GetSprite()
        {
            return default;
        }

        public virtual int[] ConsentEffect()
        {
            return new[] { 0, 0, 0, 0 };
        }
        
        public virtual int[] EffectOnFailure()
        {
            return new[] { 0, 0, 0, 0 };
        }
    }
}