using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public PlayerMove _move;
    public Animator _anim;

    private bool _isGrounded = false;

    private void Start()
    {
      //  _move = GetComponent<PlayerMove>();
     //   _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        _anim.SetFloat("XVelocity", _move.GetXVelocity());
        _anim.SetFloat("YVelocity", _move.GetYVelocity());


        if(_move.OnGround && !_isGrounded)
            _anim.SetTrigger("IsGrouned");

        _isGrounded = _move.OnGround;
    }
}