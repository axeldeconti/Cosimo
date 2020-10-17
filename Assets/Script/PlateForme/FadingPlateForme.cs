using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadingPlateForme : MonoBehaviour
{
	public SpriteRenderer sprite;
	public GameObject PlateForme;
	public float PlateFormeCoolDown;

	public void OnCollision()
	{
		StartCoroutine(FadePlateForme());
	}

	 IEnumerator FadePlateForme()
	{
		yield return StartCoroutine(Fade());
		PlateForme.SetActive(false);
	}

	 IEnumerator Fade()
	{
		Color spriteColor = sprite.color;
		for (float i = 1; i > 0; i -= Time.deltaTime / PlateFormeCoolDown)
		{
			sprite.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, i);
			yield return null;
		}
		sprite.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, 0);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		OnCollision();
	}
}
