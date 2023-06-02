using UnityEngine;
using DG.Tweening;
using System;

public class CameraFollow2D : Singleton<CameraFollow2D>
{
	Camera cam;
	static float rotStrenght;
	private bool isCameraShaking = false;
    private static event Action CamShake;
	public static void Shake(float power)
	{
		rotStrenght = power;
        CamShake?.Invoke();
	}
	private void OnEnable() { CamShake += CameraShake; }
	private void OnDisable() { CamShake -= CameraShake; }
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    private void CameraShake()
	{
		if (isCameraShaking) return;

		isCameraShaking = true;
		cam.DOShakeRotation(0.5f, rotStrenght).OnComplete(() =>
		{
			isCameraShaking = false;
		});
	}
}
