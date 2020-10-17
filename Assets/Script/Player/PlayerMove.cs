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


    public float CircleRadius;
    public LayerMask GroundLayer;

    // Update is called once per frame
    void Update()
    {
        WalkInDirection(GetDirectionToWalk());
        CheckCollision();
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            Jump();
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
        Vector2 Velocity= new Vector2(GetVelocity().x, 0);
        Velocity += (Vector2.up * Jumpforce);
        RB.velocity = Velocity;
        OnGround = false;
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position + (Vector2.up * BottomOffset),CircleRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + (Vector2.right * RightOffset),CircleRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position - (Vector2.right * LeftOffset),CircleRadius);
	}
}
