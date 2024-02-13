using UnityEngine;
using XNode;

namespace _Source.PersonNode
{
    public class BasePerson : Node
    {
        public virtual string GetLeftSwapTrigger()
        {
            return null;
        }
        
        public virtual string GetRightSwapTrigger()
        {
            return null;
        }
        
        public virtual string GetBackSwapTrigger()
        {
            return null;
        }
        
        public virtual string GetString()
        {
            return null;
        }

        public virtual Sprite GetSprite()
        {
            return null;
        }

        public virtual void ConsentEffect()
        {
            
        }
        
        public virtual void EffectOnFailure()
        {
            
        }
    }
}