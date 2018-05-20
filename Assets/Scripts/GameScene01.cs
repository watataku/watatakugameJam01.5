using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
                 
public class GameScene01 : MonoBehaviour {

	public Text timerText;
	private float time;
	private float recordTime;

	// Use this for initialization
	void Start ()
	{
		time = 0.0f;
	}

	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;
		timerText.text = "Time: " + time;
		if(Input.GetKey(KeyCode.Space)){
			SceneManager.LoadScene("GameScene01");
		}
	}
}
