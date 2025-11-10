using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	public static Player instancia;

	[SerializeField] private Rigidbody2D rb2d;
	[SerializeField] private Animator anim;

	public bool yaVolo, estaVivo;
	public float ValorOffSet = 0;

	private float Velocidad = 3.0f, fuerzarebote = 4.0f;
	private Button btnVolar;

	private int score;
	private int record;

	public AudioSource reproductor;
	public AudioClip sonidoPuntos, SonidoDeath, SonidoVuelo;

	public Text txtScore;
	public Text txtRecord;

	public GameObject gameOverPanel;
	public Text txtFinalScore;
	public Text txtFinalRecord;

	void Awake()
	{
		score = 0;
		if (instancia == null)
		{
			instancia = this;
		}

		estaVivo = true;

		btnVolar = GameObject.FindGameObjectWithTag("btnVolar").GetComponent<Button>();
		btnVolar.onClick.AddListener(() => Vuela());

		AsiganPosXCamara();

		record = PlayerPrefs.GetInt("record", 0);
		txtRecord.text = "Record: " + record.ToString();
		txtScore.text = "Puntaje: 0";
	}

	void FixedUpdate()
	{
		if (estaVivo)
		{
			Vector3 temp = transform.position;
			temp.x += Velocidad * Time.deltaTime;
			transform.position = temp;

			if (yaVolo)
			{
				yaVolo = false;
				rb2d.linearVelocity = new Vector2(0, fuerzarebote);
				anim.SetTrigger("volando");
				reproductor.clip = SonidoVuelo;
				reproductor.Play();
			}

			if (rb2d.linearVelocity.y >= 0)
			{
				transform.rotation = Quaternion.Euler(0, 0, 0);
			}
			else
			{
				float angulo = Mathf.Lerp(0, -90, -rb2d.linearVelocity.y / 21);
				transform.rotation = Quaternion.Euler(0, 0, angulo);
			}
		}
	}

	private void AsiganPosXCamara()
	{
		Camara.offsetX = Camera.main.transform.position.x - transform.position.x - ValorOffSet;
	}

	public float ObtenPosX()
	{
		return transform.position.x;
	}

	private void Vuela()
	{
		yaVolo = true;
	}

	private void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.tag == "tuboGrupo")
		{
			score++;
			txtScore.text = "Puntaje: " + score.ToString();

			reproductor.clip = sonidoPuntos;
			reproductor.Play();

			if (score > record)
			{
				record = score;
				PlayerPrefs.SetInt("record", record);
				txtRecord.text = "Record: " + record.ToString();
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "piso" || obj.gameObject.tag == "tubo")
		{
			if (estaVivo)
			{
				estaVivo = false;
				anim.SetTrigger("muere");
				reproductor.clip = SonidoDeath;
				reproductor.Play();

				txtScore.text = "Puntaje: " + score.ToString();

				gameOverPanel.SetActive(true);
				txtFinalScore.text = "Puntaje: " + score.ToString();
				txtFinalRecord.text = "Record: " + record.ToString();

				txtScore.gameObject.SetActive(false);
				txtRecord.gameObject.SetActive(false);
				btnVolar.gameObject.SetActive(false);
			}
		}
	}

	public void IrAlMenu()
	{
		SceneManager.LoadScene("Titulo 1");
	}
	
	public void ReiniciarJuego()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	
}
