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
    public bool OnWall;

    float CircleCastOffset;

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
        OnGround = Physics2D.OverlapCircle(transform.position, CircleRadius,GroundLayer);
        OnGround = Physics2D.OverlapCircle(transform.position, CircleRadius,GroundLayer);
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
        return new Vector2(GetXInput(),GetYInput());
    }


    public void WalkInDirection(Vector2 dir)
	{
        RB.velocity = new Vector2(dir.x * Speed, RB.velocity.y);
	}


    public void Jump()
	{
        RB.velocity = new Vector2(RB.velocity.y, 0);
        RB.velocity += (Vector2.up * Jumpforce); 
        OnGround = false;
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position, CircleRadius);
	}
}
