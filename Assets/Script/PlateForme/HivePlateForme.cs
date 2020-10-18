using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HivePlateForme : MonoBehaviour
{
	int BouncCount;
	public int ExcpectedBounceCount;
	bool BounceEnable;



	public UnityEvent events;
	public UnityEvent eventsOnBounce;

	public void BounceOn()
	{
		BounceEnable = true;
	}

	void BounceOff()
	{
		BounceEnable = false;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if(BounceEnable)
		{
			BouncCount++;
			BounceOff();
			eventsOnBounce.Invoke();
		}
	}


	public void Update()
	{
		if(BouncCount >= ExcpectedBounceCount)
		{
			events.Invoke();
			BouncCount = 0;
		}
	}

}
