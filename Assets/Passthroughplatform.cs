using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passthroughplatform : MonoBehaviour
{
    private Collider2D _collider;
    private bool _playerOnPlatform;
    public GameObject _player;
    // Start is called before the first frame update
    private void Start()
    {
        _collider = GetComponent<Collider2D>();


    }

    private void Update()
    {
        if(_playerOnPlatform && Input.GetAxisRaw("Vertical") < 0)
        {
            _collider.enabled = false;
            StartCoroutine(EnableCollider());
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        _collider.enabled = true;
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        //var _player = other.gameObject.GetComponent<Player>();
        if (_player != null)
        {
            _playerOnPlatform = value;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

}
