using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlateForme : MonoBehaviour
{
	public Rigidbody2D CurrentRB;
	[Range(0.0f, 1.0f)]
	public float StickyIntensity;

	private void Update()
	{
		if(CurrentRB != null)
		{
			float CurrentXVelocity = CurrentRB.velocity.x;
			CurrentRB.velocity -= new Vector2(CurrentXVelocity * StickyIntensity,0);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		CurrentRB = collision.gameObject.GetComponent<Rigidbody2D>();
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		CurrentRB = null;
	}
}
