using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

public class Ghost : MonoBehaviour
{
    public Sprite[] timerSprites;
    public SpriteRenderer timerRenderer;
    private float timerValue;

    public float flashTime;
    public float ghostInterval;
    private new Rigidbody2D rigidbody;
    private new Collider2D collider;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        timerRenderer.sprite = timerSprites[0];

        DOTween.Sequence()
            .InsertCallback(ghostInterval - flashTime, () => {
                spriteRenderer.DOFade(0.6f, flashTime / 10f).SetLoops(10, LoopType.Yoyo);
            })
            .InsertCallback(ghostInterval, () => {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                collider.enabled = false;
                spriteRenderer.DOKill();
                spriteRenderer.color = new Color(1, 1, 1, 0.4f);

                timerValue = 1;
                DOTween.To(() => timerValue, v => timerValue = v, 0f, ghostInterval)
                    .SetEase(Ease.Linear).SetTarget(this).SetLink(gameObject);
            })
            .InsertCallback(2 * ghostInterval - flashTime, () => {
                spriteRenderer.DOFade(0.8f, flashTime / 10f).SetLoops(10, LoopType.Yoyo);
            })
            .InsertCallback(2 * ghostInterval, () => {
                rigidbody.constraints = RigidbodyConstraints2D.None;
                collider.enabled = true;
                spriteRenderer.DOKill();
                spriteRenderer.color = new Color(1, 1, 1, 1f);

                timerValue = 0;
            })
            .SetLoops(-1)
            .SetTarget(this)
            .SetLink(gameObject)
            .SetUpdate(UpdateType.Fixed);
    }

    private void Update() {
        timerRenderer.sprite = timerSprites[Mathf.CeilToInt(timerValue * (timerSprites.Length - 1))];
    }

}
