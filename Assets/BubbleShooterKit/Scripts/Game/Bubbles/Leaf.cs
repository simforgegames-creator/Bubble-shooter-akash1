using UnityEngine;

namespace SimForge.Games.BubbleShooter.Blaze
{
	public class Leaf : MonoBehaviour
	{
		public FxPool FxPool;

		Animator animator;
		GameObject mouth;
		GameObject tears;
		
		const float DestroyDelay = 2.0f;
		bool destroy;
		float accTime;

		void Awake()
		{
			animator = GetComponent<Animator>();
			mouth = transform.GetChild(1).gameObject;
			tears = transform.GetChild(2).gameObject;
		}
		
		protected virtual void OnEnable()
		{
			destroy = false;
			accTime = 0.0f;
		}
		
		public void PlayParticleFx()
		{
			var particles = FxPool.LeafParticlePool.GetObject();
			particles.transform.position = transform.position;
		}

		public void Destroy()
		{
			destroy = true;
		}
		
		void Update()
		{
			if (destroy)
			{
				accTime += Time.deltaTime;
				if (accTime >= DestroyDelay)
				{
					animator.SetTrigger("Reset");
					mouth.transform.localScale = Vector3.one;
					tears.SetActive(true);
					GetComponent<PooledObject>().Pool.ReturnObject(gameObject);
				}
			}
		}
	}
}
