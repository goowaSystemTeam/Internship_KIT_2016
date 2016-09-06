using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public void toMainScene()
	{
		SceneManager.LoadScene("Main");
	}

}