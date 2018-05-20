using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
	public float m_speed;   //速さ
	public Text scoreText;  //スコアのUI
	public Text winText;

	private Rigidbody rb;
	private int score;
	private float time;

	public GameObject wall1;
	public GameObject wall2;
	public GameObject wall3;
	public int m_damage1;
	public int m_damage2;
	public int m_damage3;

	public AudioClip m_getItem;
	public AudioClip m_damage;
	public AudioClip m_gameClear;

	// Use this for initialization
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		score = 0;
		SetCountText();
		winText.text = "";
	}

	// Update is called once per frame
	void Update()
	{
		var moveHorizontal = Input.GetAxis("Horizontal");
		var moveVertical = Input.GetAxis("Vertical");

		var movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce(movement * m_speed);

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Item"))
		{
			other.gameObject.SetActive(false);
			score++;
			var audioSource = FindObjectOfType<AudioSource>();
			audioSource.PlayOneShot(m_getItem);
			SetCountText();
		}
        if (other.gameObject.CompareTag("Obstacle"))
		{
			gameObject.SetActive(false);
			winText.text = "GameOver";
			var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(m_damage);
			SetCountText();
		}
        if (other.gameObject.CompareTag("Finish"))
		{
			other.gameObject.SetActive(false);
			SetCountText();
		}
		if (other.gameObject.CompareTag("BigItem"))
		{
			other.gameObject.SetActive(false);
			score += 1000;
			winText.text = "GameClear!!";
			var audioSource = FindObjectOfType<AudioSource>();
            audioSource.PlayOneShot(m_gameClear);
			SetCountText();
		}
	}
	void SetCountText()
	{
		scoreText.text = "Count: " + score.ToString();
		if(score >= m_damage1){
			wall1.gameObject.SetActive(false);
		}
		if (score >= m_damage2){
			wall2.gameObject.SetActive(false);
		}
		if (score >= m_damage3){
			wall3.gameObject.SetActive(false);
		}
	}   
}