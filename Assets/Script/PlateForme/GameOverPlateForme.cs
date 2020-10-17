using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPlateForme : MonoBehaviour
{
	public Transform restart;
	public Transform Player;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			Player.position = restart.position;
		}
	}
}
