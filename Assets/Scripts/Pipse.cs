using UnityEngine;

public class Pipse : MonoBehaviour
{
    [Header("EnemyParams")]
    [SerializeField] private float m_speed = 5f;
    [SerializeField] private float leftEdge;

    [Header("Sprites")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private int spriteIndex;

    [Header("SwingParams")]
    [SerializeField] private float m_spawnPointY;
    [SerializeField] private float m_pointY;
    [SerializeField] private float m_speedY = 1f;
    [SerializeField] private bool m_revers = false;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
        m_spawnPointY = transform.position.y;
        InvokeRepeating(nameof(AnimateSprite), .15f, .15f);
    }
    private void Update()
    {
        transform.position += Vector3.left * m_speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }

        if (transform.position.y > m_spawnPointY + m_pointY)
        {
            m_revers = true;
        }
        else if (transform.position.y < m_spawnPointY - m_pointY)
        {
            m_revers = false;
        }

        transform.position += Vector3.up * m_speedY * Time.deltaTime * (m_revers ? -1:1);
    }
    private void AnimateSprite()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

}
