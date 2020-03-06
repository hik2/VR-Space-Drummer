using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
	private Vector3 originPosition;
	private Quaternion originRotation;
	public bool shaking = false;

	public float shake_decay = 0.002f;
	public float shake_intensity = .3f;

	private float temp_shake_intensity = 0;

    void Start()
    {
		originPosition = transform.position;
		originRotation = transform.rotation;
		//temp_shake_intensity = shake_intensity;
	}

    void Update()
	{
        if(shaking)
        {
			temp_shake_intensity = shake_intensity;
		}

		VibrateSelf();
	}

    void VibrateSelf()
    {
		if (temp_shake_intensity > 0)
		{
			transform.position = originPosition + Random.insideUnitSphere * temp_shake_intensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.y + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.z + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f,
				originRotation.w + Random.Range(-temp_shake_intensity, temp_shake_intensity) * .2f);
			temp_shake_intensity -= shake_decay;
		}
		//temp_shake_intensity = shake_intensity;
	}
}
