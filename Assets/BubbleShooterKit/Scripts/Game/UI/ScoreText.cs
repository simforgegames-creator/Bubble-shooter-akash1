using DG.Tweening;
using TMPro;
using UnityEngine;
namespace SimForge.Games.BubbleShooter.Blaze
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] float textDuration = 1.0f;
        [SerializeField] float fadeDuration = 0.2f;
        [SerializeField] TextMeshPro scoreText = null;
        [SerializeField] TextMeshPro scoreTextBorder = null;
        float accTime;
        public void Initialize(int score)
        {
            scoreText.text = score.ToString();
            scoreTextBorder.text = scoreText.text;
        }
        void OnEnable()
        {
            scoreText.alpha = 1.0f;
            scoreTextBorder.alpha = 1.0f;
        }
        void Update()
        {
            accTime += Time.deltaTime;
            if (accTime >= textDuration)
            {
                accTime = 0.0f;
                var seq = DOTween.Sequence();
                scoreText.DOFade(0.0f, fadeDuration);
                seq.Append(scoreTextBorder.DOFade(0.0f, fadeDuration));
                seq.AppendCallback(() => GetComponent<PooledObject>().Pool.ReturnObject(gameObject));
            }
        }
    }
}
