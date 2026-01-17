using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class InputDetector : MonoBehaviour
	{
		[SerializeField]
		GameScreen gameScreen = null;
		[SerializeField]
		PlayerBubbles playerBubbles = null;
		[SerializeField]
		Shooter shooter = null;
		[SerializeField]
		GameObject swapBubblesIcon = null;
		[SerializeField]
		GameObject energyOrb = null;
		
		Camera mainCamera;

		void Awake()
		{
			Assert.IsNotNull(gameScreen);
			Assert.IsNotNull(playerBubbles);
			Assert.IsNotNull(shooter);
			Assert.IsNotNull(swapBubblesIcon);
			Assert.IsNotNull(energyOrb);
		}
		
		void Start()
		{
			mainCamera = Camera.main;
		}
		
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (gameScreen.CurrentPopups.Count > 0)
					return;
				
				var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
				
				var pointer = new PointerEventData(EventSystem.current);
				pointer.position = mainCamera.WorldToScreenPoint(mousePos);
				var raycastResults = new List<RaycastResult>();
				EventSystem.current.RaycastAll(pointer, raycastResults);
				if (raycastResults.Count > 0 &&
				    (raycastResults[0].gameObject == swapBubblesIcon || raycastResults[0].gameObject == energyOrb))
				{
					shooter.SetInputEnabled(false);
					playerBubbles.ProcessInput(raycastResults[0].gameObject);
				}
				else
				{
					var hit = Physics2D.Raycast(mousePos, Vector3.forward);
					if (hit.collider != null)
					{
						shooter.SetInputEnabled(false);
						playerBubbles.ProcessInput(hit.collider.gameObject);
					}
					else
					{
						shooter.SetInputEnabled(true);
					}
				}
			}
		}
	}
}
