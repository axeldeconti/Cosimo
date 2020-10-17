using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerMove _move = null;
    private Animator _anim = null;

    private bool _isGrounded = false;

    private void Start()
    {
        _move = GetComponent<PlayerMove>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _anim.SetFloat("XVelocity", 0);
        _anim.SetFloat("YVelocity", 0);

        if(_move.OnGround && !_isGrounded)
            _anim.SetTrigger("IsGrouned");
    }
}