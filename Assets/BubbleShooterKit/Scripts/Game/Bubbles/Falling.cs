using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class Falling : MonoBehaviour
	{
		SpriteRenderer spriteRenderer;
		CircleCollider2D circleCollider;
		Rigidbody2D body;
		bool falling;

		void Awake()
		{
			spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
			circleCollider = GetComponent<CircleCollider2D>();
			body = GetComponent<Rigidbody2D>();
		}
		
		public void Fall()
		{
			falling = true;
			circleCollider.enabled = false;
			var sign = Random.Range(0, 2);
			var x = Random.Range(GameplayConstants.FallingMinXForce, GameplayConstants.FallingMaxXForce);
			var y = Random.Range(GameplayConstants.FallingMinYForce, GameplayConstants.FallingMaxYForce);
			body.linearVelocity = new Vector2(sign == 0 ? x : -x, y);
			FadeOutSprite();
			if (gameObject.activeInHierarchy)
				StartCoroutine(AutoDestroy());
		}

		void OnEnable()
		{
			falling = false;
			if (spriteRenderer != null)
			{
				var newColor = spriteRenderer.color;
				newColor.a = 1.0f;
				spriteRenderer.color = newColor;
			}
			circleCollider.enabled = true;
		}
		
		void FixedUpdate()
		{
			if (falling)
				body.linearVelocity = body.linearVelocity + (Physics2D.gravity * GameplayConstants.FallingGravityMultiplier * Time.fixedDeltaTime);
		}

		void FadeOutSprite()
		{
			var seq = DOTween.Sequence();
			seq.AppendInterval(GameplayConstants.FallingFadeOutDelay);
			seq.Append(spriteRenderer.DOFade(0.0f, GameplayConstants.FallingFadeOutDuration));
			seq.Play();
		}

		IEnumerator AutoDestroy()
		{
			var colorBubble = GetComponent<ColorBubble>();
			if (colorBubble != null && colorBubble.CoverType != CoverType.None)
			{
				colorBubble.CoverType = CoverType.None;
				var cover = transform.GetChild(1).gameObject;
				cover.GetComponent<PooledObject>().Pool.ReturnObject(cover);
			}
			yield return new WaitForSeconds(2.0f);
			GetComponent<PooledObject>().Pool.ReturnObject(gameObject);
		}
	}
}
