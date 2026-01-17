using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class BubbleShooterKitEditor : EditorWindow
	{
		readonly List<EditorTab> tabs = new List<EditorTab>();

		int selectedTabIndex = -1;
		int prevSelectedTabIndex = -1;

		[MenuItem("Tools/Bubble Shooter Kit/Editor", false, 0)]
		static void Init()
		{
			var window = GetWindow(typeof(BubbleShooterKitEditor));
			window.titleContent = new GUIContent("Bubble Shooter Kit Editor");
		}

		void OnEnable()
		{
			tabs.Add(new GameSettingsTab(this));
			tabs.Add(new LevelEditorTab(this));
			selectedTabIndex = 0;
		}

		void OnGUI()
		{
			selectedTabIndex = GUILayout.Toolbar(selectedTabIndex,
				new[] {"Game settings", "Level editor"});
			if (selectedTabIndex >= 0 && selectedTabIndex < tabs.Count)
			{
				var selectedEditor = tabs[selectedTabIndex];
				if (selectedTabIndex != prevSelectedTabIndex)
				{
					selectedEditor.OnTabSelected();
					GUI.FocusControl(null);
				}
				selectedEditor.Draw();
				prevSelectedTabIndex = selectedTabIndex;
			}
		}
	}
}
