using UnityEditor;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class CollectLeavesGoal : LevelGoal
	{
		public int Amount;

		public override bool IsComplete(GameState state)
		{
			return state.CollectedLeaves >= Amount;
		}

		public override string ToString()
		{
			return $"Collect {Amount} leaves";
		}

#if UNITY_EDITOR
		public override void Draw()
		{
			GUILayout.BeginVertical();

			GUILayout.BeginHorizontal();
			EditorGUILayout.PrefixLabel("Amount");
			Amount = EditorGUILayout.IntField(Amount, GUILayout.Width(30));
			GUILayout.EndHorizontal();

			GUILayout.EndVertical();
		}
#endif
	}
}
