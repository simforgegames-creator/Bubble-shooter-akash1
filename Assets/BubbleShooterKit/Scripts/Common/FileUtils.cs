using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public static class FileUtils
	{
		public static LevelInfo LoadLevel(int levelNum)
		{
			return Resources.Load<LevelInfo>($"Levels/{levelNum}");
		}
		
        public static bool FileExists(string path)
        {
            var level = Resources.Load<LevelInfo>(path);
            return level != null;
        }
	}
}
