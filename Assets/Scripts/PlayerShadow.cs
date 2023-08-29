using UnityEngine;

public class PlayerShadow : MonoBehaviour
{
    [Header("ShadowParams")]
    [SerializeField] private float m_speed = 5f;
    [SerializeField] private float m_scaler = .97f;
    [SerializeField] private float leftEdge;

    [Header("Body")]
    [SerializeField] private SpriteRenderer m_body;

    public void SetSprite(Sprite _sprite)
    {
        m_body.sprite = _sprite;
    }
    private void Update()
    {
        transform.position += Vector3.left * m_speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
        if (transform.localScale.y > 0)
        {
            transform.localScale = transform.localScale * m_scaler;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
