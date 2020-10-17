using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlateForme : MonoBehaviour
{
	public Rigidbody2D RB;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		RB.constraints = RigidbodyConstraints2D.None;
		RB.constraints = RigidbodyConstraints2D.FreezePositionX;
	}
}
