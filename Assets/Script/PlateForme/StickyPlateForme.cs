using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlateForme : MonoBehaviour
{
	public PlayerMove player;
	[Range(0.0f, 1.0f)]
	public float StickyIntensity;

	private void Update()
	{
		if(player != null)
		{
			float CurrentXVelocity = player.GetVelocity().x;
			player.AddForce(- new Vector2(CurrentXVelocity * StickyIntensity,0));
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			player = collision.gameObject.GetComponent<PlayerMove>();
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			player = null;
		}
	}
}
