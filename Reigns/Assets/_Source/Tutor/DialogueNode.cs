using UnityEngine;

namespace _Source.Tutor
{
	public class DialogueNode : BaseNode
	{
		[Input] public int entry;
		[Output] public int exit;

		public string _speakerName;
		public string _dialogueLine;
		public Sprite _sprite;

		public override string GetString()
		{
			return $"DialogueNode/{_speakerName}/{_dialogueLine}";
		}

		public override Sprite GetSprite()
		{
			return _sprite;
		}
	}
}