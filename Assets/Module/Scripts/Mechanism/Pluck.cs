using System;
using UnityEngine;

public class Pluck : MonoBehaviour
{
    [Header("Physics Settings")]
    [SerializeField] float _bounceVelocity;
    private Rigidbody2D m_rb;
    private bool m_isAlive;

    [Header("Events")]
    public static Action _onGoal;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionPoint = collision.collider.ClosestPoint(transform.position);
        Vector2 normalVector = ((Vector2)transform.position - collisionPoint).normalized;
        Bounce(normalVector);
    }

    private void Bounce(Vector2 normal)
    {
        m_rb.linearVelocity = normal * _bounceVelocity;
    }
}
