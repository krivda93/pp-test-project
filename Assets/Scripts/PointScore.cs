using UnityEngine;

public class PointScore : MonoBehaviour
{
    [Header("PointParams")]
    [SerializeField] private float leftEdge;
    [SerializeField] private float m_speed = 1f;
    [SerializeField] private GameObject m_target;
    private void Update()
    {
        transform.position += Vector3.left * m_speed * Time.deltaTime;
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
        if (m_target != null)
        {
            Vector3 direction = Vector3.ClampMagnitude(m_target.transform.position - transform.position, 1f);
            transform.position += direction * m_speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_target = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_target = null;
        }
    }
}
