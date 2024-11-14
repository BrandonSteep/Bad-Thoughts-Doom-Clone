using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObstacleController : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private float _spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        _anim.SetFloat("Speed", _spinSpeed);
    }
}
