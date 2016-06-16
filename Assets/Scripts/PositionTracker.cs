using UnityEngine;
using System.Collections;

public class PositionTracker : MonoBehaviour
{

	public Transform m_trackerObject;

	Vector3 m_offset = Vector3.zero;

	void Awake ()
	{
		m_offset = transform.position;
	}

	// Use this for initialization
	void Start ()
	{
		if (m_trackerObject == null)
			Destroy (this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = m_trackerObject.position + m_offset;
	}
}
