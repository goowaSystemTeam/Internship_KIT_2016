using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {
	public float openSpeed; //ドアオープンスピード
	private bool doorOpen; //ドアチェック
	private float yDegree; //ドア回転角

	void Start()
	{
		doorOpen = false;
		yDegree = 0.0F;
	}
	void Update()
	{
		if (doorOpen)
		{
			if (yDegree<90.0F)
			{
				yDegree += openSpeed * Time.deltaTime;
				transform.Rotate (0,openSpeed * Time.deltaTime,0);
			}
		}
		else
		{
			if (yDegree> 0.0F)
			{
				yDegree -= openSpeed * Time.deltaTime;
				transform.Rotate (0,-openSpeed * Time.deltaTime,0);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		doorOpen =true;
	}
	void OnTriggerExit(Collider other)
	{
		doorOpen = false;
	}
}