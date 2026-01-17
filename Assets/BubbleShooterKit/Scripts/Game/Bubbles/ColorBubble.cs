using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	[RequireComponent(typeof(CircleCollider2D))]
	public class ColorBubble : Bubble
	{
		public ColorBubbleType Type;
		public CoverType CoverType;

		public bool Visible => transform.GetChild(0).GetComponent<UpdateVisibility>().Visible;

		float accTime;

		Transform childTransform;
		Vector3 originalScale;

		protected override void Awake()
		{
			base.Awake();
			childTransform = transform.GetChild(0);
			originalScale = childTransform.localScale;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			childTransform.localScale = originalScale;
			CoverType = CoverType.None;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			childTransform.localScale = originalScale;
			if (transform.childCount >= 2)
			{
				var cover = transform.GetChild(1);
				cover.GetComponent<PooledObject>().Pool.ReturnObject(cover.gameObject);
			}
		}

		void Update()
		{
			accTime += Time.deltaTime;
			if (accTime >= GameplayConstants.BubbleBlinkRate)
			{
				accTime = 0.0f;
				var rnd = Random.Range(0, 2);
				if (rnd == 0)
					childTransform.GetComponent<Animator>().SetTrigger("Blink");
			}
		}

		public override void ShowExplosionFx(FxPool fxPool)
		{
			var fx = fxPool.GetColorBubbleParticlePool(Type).GetObject();
			fx.transform.position = transform.position;
		}
	}
}
