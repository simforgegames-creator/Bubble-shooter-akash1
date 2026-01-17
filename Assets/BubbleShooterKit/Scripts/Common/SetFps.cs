using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{



	public class SetFps : MonoBehaviour
	{
		public int Fps = 60;
		
		void Start()
		{
			Application.targetFrameRate = Fps;
		}
	}
}
