using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private MeshRenderer m_Renderer;
    [SerializeField] private float m_speed = 1f;
    private void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        m_Renderer.material.mainTextureOffset += new Vector2(m_speed * Time.deltaTime, 0);
    }
}
