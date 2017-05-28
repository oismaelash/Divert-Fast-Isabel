using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[]    m_StonePrefab;

    private Vector3         m_PositionInstatiante;

    private void Start()
    {
        m_PositionInstatiante = transform.position;

        GetComponent<Rigidbody2D>().drag = Random.Range(-1, 4f);
    }

    //void OnBecameInvisible()
    //{
    //    PlayerManager.m_PointsHits++;
    //    GameObject go = Instantiate(m_StonePrefab[0], m_PositionInstatiante, transform.localRotation) as GameObject;
    //    Destroy(gameObject);
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("ground"))
        {
            PlayerManager.m_PointsHits++;
            GameObject go = Instantiate(m_StonePrefab[0], m_PositionInstatiante, transform.localRotation) as GameObject;
            Destroy(gameObject);
        }
    }
}
