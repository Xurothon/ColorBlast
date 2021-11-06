using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move2dObject : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    void Start()
    {
        _rigidbody2D.velocity = new Vector2(Random.Range(3, 6f), Random.Range(3, 6f));
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
}
