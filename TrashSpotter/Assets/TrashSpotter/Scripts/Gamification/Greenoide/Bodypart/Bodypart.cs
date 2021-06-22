using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bodypart : MonoBehaviour
{
    SpriteRenderer renderer;

    protected virtual void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        renderer.sprite = sprite;
    }
}
