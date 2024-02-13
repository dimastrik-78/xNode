using UnityEngine;
using XNode;

namespace _Source.Tutor
{
    public class BaseNode : Node
    {
        public virtual string GetString()
        {
            return null;
        }

        public virtual Sprite GetSprite()
        {
            return null;
        }
    }
}
