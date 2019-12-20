using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour
{
    public bool play;

    public float fps = 30.0f;
    public Sprite[] frames;

    private int frameIndex;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        frameIndex = 0;
    }
    void Update()
    {
        if (play)
        {
            PlayMuzzleFlash();
            play = false;
        }
    }
    public void PlayMuzzleFlash()
    {
        frameIndex = 0;
        NextFrame();
    }
    private void NextFrame()
    {
        spriteRenderer.sprite = frames[frameIndex];
        frameIndex = (frameIndex + 1);

        if (frameIndex < frames.Length)
        {
            Invoke("NextFrame", 0.15f);
        }
        else
        {
            frameIndex = 0;
            spriteRenderer.sprite = null;
        }
    }
}