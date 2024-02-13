namespace _Source.PersonNode
{
    public class StartNode : BasePerson
    {
        [Output] public int Exit;

        public override string GetString()
        {
            return $"Exit";
        }
    }
}