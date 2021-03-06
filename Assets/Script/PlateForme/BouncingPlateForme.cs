﻿using UnityEngine;
using UnityEngine.Events;

public class BouncingPlateForme : MonoBehaviour
{
	public float BouncingForce;
	public UnityEvent onBounce = null;

	public void OnCollision(Rigidbody2D CollidingObject,Vector3 BouncingNormalSurface)
	{
		CollidingObject.AddForce(-BouncingNormalSurface * BouncingForce);
		onBounce.Invoke();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.collider.CompareTag("Player"))
			OnCollision(collision.gameObject.GetComponent<Rigidbody2D>(), collision.contacts[0].normal);
	}
	
}
