using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class UpdateVisibility : MonoBehaviour
	{
		public bool Visible { get; set; }

		void OnBecameVisible()
		{
			Visible = true;
		}
		
		void OnBecameInvisible()
		{
			Visible = false;
		}
	}
}
