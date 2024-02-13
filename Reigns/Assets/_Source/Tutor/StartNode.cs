using _Source.PersonNode;

namespace _Source.Tutor
{
    public class StartNode : BaseNode
    {
        [Output] public int exit;

        public override string GetString()
        {
            return "Start";
        }
    }
}