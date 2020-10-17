using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGamePlateForme : MonoBehaviour
{
	public CinemachineVirtualCamera PlayerCamera;
	public AnimationCurve Transition;
	CinemachineTrackedDolly trackedDolly;
	public float TransitionDuration;
	public float CurrentCameraPosition;
	public void Start()
	{
		trackedDolly = PlayerCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		StartCoroutine(EndLevel());
	}


	IEnumerator EndLevel()
	{
		yield return StartCoroutine(EndLevelFeedBack());
		yield return StartCoroutine(CameraTransition());
	}
	IEnumerator EndLevelFeedBack()
	{
		yield return new WaitForSeconds(1.0f);
	}

	IEnumerator CameraTransition()
	{
		float NextCameraPosition = CurrentCameraPosition + 1;
		for(float i = CurrentCameraPosition; i < NextCameraPosition; i+= Time.deltaTime/ TransitionDuration)
		{
			trackedDolly.m_PathPosition = Transition.Evaluate(i);
			yield return null;
		}
		CurrentCameraPosition = NextCameraPosition;
	}
}
