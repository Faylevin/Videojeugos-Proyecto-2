using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instancia;
	[SerializeField] private Rigidbody2D rb2d;
	[SerializeField] private Animator anim;
	public bool yaVolo, estaVivo;
	public float ValorOffSet = 0;
	
	
	private float Velocidad = 3.0f , fuerzarebote = 4.0f;
	private Button btnVolar;

	
    // Start is called before the first frame update
	void Awake()
	{
		if(instancia == null){
			instancia = this;
		}
		estaVivo = true;
		btnVolar = GameObject.FindGameObjectWithTag("btnVolar").GetComponent<Button>();
		btnVolar.onClick.AddListener(() => Vuela());
		AsiganPosXCamara();
	}



    // Update is called once per frame
    void FixedUpdate()
    {
        if(estaVivo){
	        Vector3 temp = transform.position;
	        temp.x += Velocidad * Time.deltaTime;
	        transform.position = temp;
	        
	        
	        if(yaVolo){
	        	yaVolo = false;
	        	rb2d.linearVelocity = new Vector2(0,fuerzarebote);
	        	anim.SetTrigger("volando"); //Revisar Igual que el proyecto
	        }
	        if(rb2d.linearVelocity.y >= 0 ){
	        	transform.rotation = Quaternion.Euler(0,0,0);
	        }else{
	        	float angulo = 0;
	        	angulo = Mathf.Lerp(0, -90, -rb2d.linearVelocity.y / 21);
	        	transform.rotation = Quaternion.Euler(0,0,angulo);
	        }
	        
        }
    }

	private void AsiganPosXCamara(){
		Camara.offsetX = Camera.main.transform.position.x - transform.position.x - ValorOffSet;
	}
    
    
	public float ObtenPosX(){
		return transform.position.x;
	}
    

    private void Vuela(){
	    yaVolo = true;
    }
}
