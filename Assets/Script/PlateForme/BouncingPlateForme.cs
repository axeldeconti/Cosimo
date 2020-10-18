using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlateForme : MonoBehaviour
{
	public float BouncingForce;

	public void OnCollision(Rigidbody2D CollidingObject,Vector3 BouncingNormalSurface)
	{
		CollidingObject.AddForce(-BouncingNormalSurface * BouncingForce);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		OnCollision(collision.gameObject.GetComponent<Rigidbody2D>(), collision.contacts[0].normal);
	}
	
}
