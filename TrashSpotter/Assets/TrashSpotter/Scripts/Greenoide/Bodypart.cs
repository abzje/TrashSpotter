using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Bodypart : MonoBehaviour
{
    SpriteRenderer _Renderer;

    void Awake()
    {
        _Renderer = GetComponent<SpriteRenderer>();
    }

    public void SetSprite(Sprite sprite)
    {
        _Renderer.sprite = sprite;
    }
}
