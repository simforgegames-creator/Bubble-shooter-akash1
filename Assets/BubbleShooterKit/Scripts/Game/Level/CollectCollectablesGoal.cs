using UnityEditor;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class CollectCollectablesGoal : LevelGoal
	{
		public CollectableBubbleType Type;
		public int Amount;

		public override bool IsComplete(GameState state)
		{
			return state.CollectedCollectables[Type] >= Amount;
		}

		public override string ToString()
		{
			return $"Collect {Amount} collectables";
		}

#if UNITY_EDITOR
		public override void Draw()
		{
			GUILayout.BeginVertical();

			GUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Type");
			Type = (CollectableBubbleType) EditorGUILayout.EnumPopup(Type, GUILayout.Width(100));
			GUILayout.EndHorizontal();

			GUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Amount");
			Amount = EditorGUILayout.IntField(Amount, GUILayout.Width(30));
			GUILayout.EndHorizontal();

			GUILayout.EndVertical();
		}
#endif
	}
}
