using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPlateForme : MonoBehaviour
{
	public Transform restart;
	public Transform Player;


    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.collider.CompareTag("Player"))
		{
			Player.position = restart.position;
		}
	}
}
