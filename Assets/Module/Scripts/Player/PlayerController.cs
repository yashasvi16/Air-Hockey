using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float[] _rangeX = new float[2];
    [SerializeField] float[] _rangeY = new float[2];

    private Vector2 m_mousePosition = Vector2.zero;

    void Update()
    {
        if(!(GameManager._gameState == GAME_STATE.RUNNING))
            return;

        HandleInputAndMovement();
    }

    private void HandleInputAndMovement()
    {
        if(Input.GetMouseButton(0))
        {
            m_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Move();
        }
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_mousePosition, _moveSpeed * Time.deltaTime);
        transform.position = ClampPosition();
    }

    private Vector2 ClampPosition()
    {
        Vector2 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, _rangeX[0], _rangeX[1]);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, _rangeY[0], _rangeY[1]);

        return clampedPosition;
    }
}
