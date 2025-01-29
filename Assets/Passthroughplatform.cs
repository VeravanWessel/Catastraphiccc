using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passthroughplatform : MonoBehaviour
{
    private Collider2D _collider;
    private bool _playerOnPlatform;
    // Start is called before the first frame update
    private void Start()
    {
        _collider = GetComponent<Collider2D>();


    }

}
