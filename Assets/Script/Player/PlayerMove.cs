using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D RB;
    public float Speed;
    public float Jumpforce;

    public bool OnGround;
    public bool OnWallLeft;
    public bool OnWallRight;

    public float BottomOffset;
    public float LeftOffset;
    public float RightOffset;

    public float JumpDuration;

    public float CircleRadius;
    public LayerMask GroundLayer;

    public float FallMultiplier;
    public float LowJumpMultiplier;



    // Update is called once per frame
    void Update()
    {
            WalkInDirection(GetDirectionToWalk());
            CheckCollision();
            if (Input.GetKeyDown(KeyCode.Space) && OnGround)
            {
                Jump();
                OnGround = false;
            }
            BetterJump();
    }

    public void BetterJump()
	{
        if(RB.velocity.y < 0)
		{
            RB.velocity += Vector2.up * Physics2D.gravity.y * (FallMultiplier - 1) * Time.deltaTime;
		}
        else if(RB.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
		{
            RB.velocity += Vector2.up * Physics2D.gravity.y * (LowJumpMultiplier - 1) * Time.deltaTime;
        }
	}

    public void CheckCollision()
	{
        OnGround = Physics2D.OverlapCircle(transform.position + (Vector3.up * BottomOffset), CircleRadius,GroundLayer);
        OnWallRight = Physics2D.OverlapCircle(transform.position + (Vector3.right * RightOffset), CircleRadius,GroundLayer);
        OnWallLeft = Physics2D.OverlapCircle(transform.position - (Vector3.right * LeftOffset), CircleRadius, GroundLayer);
    }

    public float GetXInput()
	{
        return Input.GetAxis("Horizontal");
    }

    public float GetYInput()
    {
        return Input.GetAxis("Vertical");
    }

    public Vector2 GetDirectionToWalk()
	{
        return new Vector2(GetXInput(), GetYInput());
    }

    public float GetXVelocity()
	{
        return RB.velocity.x;
	}
    public float GetYVelocity()
    {
        return RB.velocity.y;
    }

    public void WalkInDirection(Vector2 dir)
	{
        RB.velocity = new Vector2(dir.x * Speed,GetVelocity().y);
	}

    public Vector3 GetVelocity()
	{
       return RB.velocity;
    }

    public void AddForce(Vector2 forces)
	{
        RB.velocity += forces;
	}

    public void Jump()
	{
        RB.velocity += (Vector2.up * Jumpforce);
	}

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position + (Vector2.up * BottomOffset),CircleRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + (Vector2.right * RightOffset),CircleRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position - (Vector2.right * LeftOffset),CircleRadius);
	}
}
