using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Prefubs")]
    [SerializeField] private GameObject m_preFubEnemy;
    [SerializeField] private GameObject m_preFubPoint;

    [Header("SpawnerParams")]
    [SerializeField] private float m_spawnRateS = .5f;
    [SerializeField] private float m_spawnRateE = 2f;
    [SerializeField] private float m_minH = -1f;
    [SerializeField] private float m_maxH = 1f;
    [SerializeField] private bool m_state = false;

    private void OnEnable()
    {
        m_state = true;
        StartCoroutine(Spawners());
        StartCoroutine(SpawnsPoint());
    }
    private void OnDisabled()
    {
        m_state = false;
        StopAllCoroutines();
    }
    private void Spawn()
    { 
        GameObject pipes = Instantiate(m_preFubEnemy, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(m_minH, m_maxH);
    }
    private void SpawnPoint()
    {
        GameObject pipes = Instantiate(m_preFubPoint, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(m_minH, m_maxH);
    }
    IEnumerator Spawners()
    {
        while (true)
        {
            if (m_state)
            {
                Spawn();
            }
            yield return new WaitForSeconds(Random.Range(m_spawnRateS, m_spawnRateE));
        }
    }
    IEnumerator SpawnsPoint()
    {
        while (true)
        {
            if (m_state)
            {
                SpawnPoint();
            }
            yield return new WaitForSeconds(Random.Range(m_spawnRateS, m_spawnRateE));
        }
    }
}