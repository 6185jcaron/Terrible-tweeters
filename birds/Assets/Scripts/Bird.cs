using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;

    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    void OnMouseUp()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        Vector2 currentPosition = GetComponent<Rigidbody2D>().position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();

        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);

    }

    void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
