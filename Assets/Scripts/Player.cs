using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PlayerParam")]
    [SerializeField] private Vector3 direction;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float str = 5f;

    [Header("Sprites")]
    [SerializeField] private SpriteRenderer m_spriteRenderer;
    [SerializeField] private Sprite[] m_sprites;
    [SerializeField] private int m_spriteIndex;

    [Header("PlayerShadow")]
    [SerializeField] private PlayerShadow m_shadow;
    [SerializeField] private float m_step = .5f;
    private void Awake()
    {
        m_spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), .15f,.15f);
        StartCoroutine(CreateShadow());
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            direction += Vector3.up * str;
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }
    private void AnimateSprite()
    {
        m_spriteIndex++;
        if (m_spriteIndex >= m_sprites.Length)
        {
            m_spriteIndex = 0;
        }
        m_spriteRenderer.sprite = m_sprites[m_spriteIndex];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
            FindObjectOfType<GameManager>().GameOver();
        else if (other.gameObject.tag == "Scoring")
        {
            Destroy(other.gameObject.transform.parent.gameObject);
            FindObjectOfType<GameManager>().IncScore();
        }
    }
    private IEnumerator CreateShadow()
    {
        while (true)
        {
            var _shadow = Instantiate(m_shadow.gameObject, transform.position, Quaternion.identity);
            _shadow.GetComponent<PlayerShadow>().SetSprite(m_spriteRenderer.sprite);
            yield return new WaitForSeconds(m_step);
        }
    }
}
