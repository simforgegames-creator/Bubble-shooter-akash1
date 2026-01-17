using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public abstract class Bubble : MonoBehaviour
	{
		public int Row;
		public int Column;
		[HideInInspector]
		public GameLogic GameLogic;

		public float Speed = 14.0f;

		public bool CollidingWithAnotherBubble;

		Vector3 shootDir;
		bool shooting;

		CircleCollider2D circleCollider;
		SpriteRenderer spriteRenderer;
		Sprite originalSprite;
		Camera mainCamera;

		public bool IsBeingDestroyed;

		protected virtual void Awake()
		{
			circleCollider = GetComponent<CircleCollider2D>();
			spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
			originalSprite = spriteRenderer.sprite;
			mainCamera = Camera.main;
		}

		protected virtual void OnEnable()
		{
			shooting = false;
			CollidingWithAnotherBubble = false;
			circleCollider.enabled = true;
			IsBeingDestroyed = false;
		}

		protected virtual void OnDisable()
		{
			spriteRenderer.sprite = originalSprite;
		}

		public virtual bool CanBeDestroyed()
		{
			return true;
		}

		public void Explode()
		{
			circleCollider.enabled = false;
		}

		public void Shoot(Vector2 dir)
		{
			shooting = true;
			shootDir = dir.normalized;
		}

		public void ForceStop()
		{
			shooting = false;
		}

		void Stop(Bubble touchedBubble)
		{
			if (shooting)
			{
				shooting = false;
				GameLogic.HandleMatches(this, touchedBubble);
			}
		}

		public void ReverseDirection()
		{
			shootDir.x *= -1;
		}

		protected void FixedUpdate()
		{
			if (shooting)
			{
				transform.position += shootDir * Speed * Time.deltaTime;
				var leftEdge = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0));
				var rightEdge = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
				if (transform.position.x - spriteRenderer.bounds.size.x / 2 <= leftEdge.x ||
				    transform.position.x + spriteRenderer.bounds.size.x / 2 >= rightEdge.x)
				{
					ReverseDirection();
				}
			}
		}

		protected void OnTriggerEnter2D(Collider2D other)
		{
			var otherBubble = other.GetComponent<Bubble>();
			if (otherBubble != null)
			{
				CollidingWithAnotherBubble = true;
				otherBubble.Stop(this);
			}
		}

		public void SetColliderEnabled(bool colliderEnabled)
		{
			circleCollider.enabled = colliderEnabled;
		}

		public virtual void ShowExplosionFx(FxPool fxPool)
		{
		}
	}
}
