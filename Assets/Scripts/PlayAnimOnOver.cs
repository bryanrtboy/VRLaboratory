using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityStandardAssets.Utility;

public class PlayAnimOnOver : MonoBehaviour
{

	public AutoMoveAndRotate m_autoMoveRotate;
	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	public float m_speedMultiplier = 2;

	float m_acceleration = 0;
	float m_startSpeed = 0;
	bool m_isOver = false;
	bool m_isRunning = false;


	// Use this for initialization
	void Awake ()
	{

		if (!m_autoMoveRotate || !m_InteractiveItem)
			Destroy (this);

		m_startSpeed = m_autoMoveRotate.rotateDegreesPerSecond.value.z;
	
	}

	private void OnEnable ()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;
		m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
	}


	private void OnDisable ()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
		m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
	}

	void Update ()
	{
		if (!m_isOver)
			m_acceleration -= 1;
		else
			m_acceleration += 1;

		if (m_acceleration > 1000) {
			m_acceleration = 1000;
		} else if (m_acceleration < 0) {
			m_acceleration = 0;
			m_isRunning = false;
		}
		if (m_isRunning)
			m_autoMoveRotate.rotateDegreesPerSecond.value = new Vector3 (0, 0, (m_startSpeed * m_speedMultiplier) + m_acceleration);
	}

	//Handle the Over event
	private void HandleOver ()
	{
		m_isOver = true;
		m_isRunning = true;
		m_autoMoveRotate.rotateDegreesPerSecond.value = new Vector3 (0, 0, (m_startSpeed * m_speedMultiplier) + m_acceleration);
	}


	//Handle the Out event
	private void HandleOut ()
	{
		m_isOver = false;
	}


	//Handle the Click event
	private void HandleClick ()
	{

	}


	//Handle the DoubleClick event
	private void HandleDoubleClick ()
	{

	}
		
	//ToDo Use a Curve to set the timer transition based on Reaktor...
}
