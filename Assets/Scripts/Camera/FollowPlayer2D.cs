using UnityEngine;

public class FollowPlayer2D : MonoBehaviour
{

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset, targetOffset;


    private void Awake()
    {
		target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnEnable()
    {
		Vector3 desiredPosition = target.position + offset;
		transform.position = desiredPosition;

		transform.LookAt(target.position + targetOffset);
	}

    void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		//transform.LookAt(target.position + targetOffset);
	}

}