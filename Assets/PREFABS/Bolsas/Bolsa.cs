using UnityEngine;
using System.Collections;

public class Bolsa : MonoBehaviour
{
	public Pallet.Valores Monto;
	public Texture2D ImagenInventario;
	Player Pj = null;
	
	bool Desapareciendo;
	public float TiempParts = 2.5f;

	void Start () 
	{
		Monto = Pallet.Valores.Valor2;	
	}
	
	void Update ()
	{		
		if(Desapareciendo)
		{
			TiempParts -= Time.deltaTime;
			if(TiempParts <= 0)
			{
				GetComponent<Renderer>().enabled = true;
				GetComponent<Collider>().enabled = true;
				
				gameObject.SetActive(false);
			}
		}
		
	}
	
	void OnTriggerEnter(Collider coll)
	{
		if(coll.tag == "Player" || coll.tag == "Player2")
        {
            Pj = coll.GetComponent<Player>();
            if (Pj.AgregarBolsa(this))
                Desaparecer();
        }
    }

    public void Desaparecer()
	{
		Desapareciendo = true;		
		GetComponent<Renderer>().enabled = false;
		GetComponent<Collider>().enabled = false;
	}
}
