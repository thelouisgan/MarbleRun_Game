using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePos : MonoBehaviour
{
	public Transform checkPoint;
	public float theX = 0f;
	public float theY = 0f;
	public float theZ = 0f;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			theX = col.GetComponent<RollingBall>().myX;
			theY = col.GetComponent<RollingBall>().myY;
			theZ = col.GetComponent<RollingBall>().myZ;
			Debug.Log("Check!--" + theX + theY + theZ);
			SaveGame();
			//col.gameObject.GetComponent<Player>().checkPoint = checkPoint.position;

			PlayerPrefs.SetFloat("SavedX", theX);
			PlayerPrefs.SetFloat("SavedY", theY);
			PlayerPrefs.SetFloat("SavedZ", theZ);
			Debug.Log("Saving file: X= " + theX + ", Y= " + theY + ", Z= " + theZ);
		}
	}

	void SaveGame()
	{
		PlayerPrefs.GetFloat("SavedFloat" + theX + theY + theZ);

	}



}
