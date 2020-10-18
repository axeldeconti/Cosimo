using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FonduFinDeJeu : MonoBehaviour
{
    public Image Picture;
    public AnimationCurve curve;
    // Start is called before the first frame update
    public void StartFade()
	{
        StartCoroutine(FadeIn());
	}

  IEnumerator FadeIn()
	{
        for(float i = 1; i >0; i-= Time.deltaTime)
		{
            Picture.color = new Color(Picture.color.r, Picture.color.g, Picture.color.b, curve.Evaluate(i));
            yield return null;
        }
        Picture.color = new Color(Picture.color.r, Picture.color.g, Picture.color.b, curve.Evaluate(1));
    }
}
