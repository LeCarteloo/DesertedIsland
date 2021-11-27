using UnityEngine;
using System.Collections;

public class PlayerControler : MonoBehaviour {

	//Obiekt odpowiedzialny za ruch gracza.
	public CharacterController characterControler;

	//Prędkość poruszania się gracza.
	public float predkoscPoruszania = 9.0f;
	//Wysokość skoku.
	public float wysokoscSkoku = 7.0f;
	//Aktualna wysokosc skoku.
	public float aktualnaWysokoscSkoku = 0f;
	//Predkosc biegania.
	public float predkoscBiegania = 7.0f;
	public float gravity = 20.0f;
	//Predkosc biegania.
	public float wPowietrzu = 7.0f;
	int temp = 0;

	//Złamana noga.
	public bool zlamanaNoga = false;
	private bool zlamanaNogaStatus = false;

	//Jedzenie
	public int jedzenie = 100;

	//woda
	public int woda = 100;

	//zdrowie
	public int hp = 100;

	//Czulość myszki (Sensitivity)
	public float czuloscMyszki = 3.0f;	
	public float myszGoraDol = 0.0f;
	//Zakres patrzenia w górę i dół.
	public float zakresMyszyGoraDol = 90.0f;

	// Use this for initialization
	void Start () {
		characterControler = GetComponent<CharacterController>();
		InvokeRepeating("jedzonko", 0, 5);
		InvokeRepeating("wodaa", 0, 10);
	}
	
	// Update is called once per frame
	void Update() {
		klawiatura();
		myszka();
	}

	private void jedzonko()
    {
		jedzenie--;
		if(jedzenie < 0)
        {
			//śmierć
        }
    }

	private void wodaa()
	{
		woda--;
		if (woda < 0)
		{
			//śmierć
		}
	}

	/**
	 * Metoda odpowiedzialna za poruszanie się na klawiaturze.
	 */
	private void klawiatura() {

		if (zlamanaNoga != zlamanaNogaStatus)
		{
			zlamanaNogaStatus = zlamanaNoga;
			if (zlamanaNoga == true)
			{
				predkoscPoruszania = 4.0f;
			}
			else
			{
				predkoscPoruszania = 7.0f;
			}
		}

		

			//Pobranie prędkości poruszania się przód/tył.
			// jeżeli wartość dodatnia to poruszamy się do przodu,
			// jeżeli wartość ujemna to poruszamy się do tyłu.
			float rochPrzodTyl = Input.GetAxis("Vertical") * predkoscPoruszania;
			//Pobranie prędkości poruszania się lewo/prawo.
			// jeżeli wartość dodatnia to poruszamy się w prawo,
			// jeżeli wartość ujemna to poruszamy się w lewo.
			float rochLewoPrawo = Input.GetAxis("Horizontal") * predkoscPoruszania;
			//Debug.Log (rochLewoPrawo);
		
		//Skakanie
		if (zlamanaNoga == true)
		{
			//gdy złamana noga podczas skoku
		}
		// Jeżeli znajdujemy się na ziemi i została naciśnięta spacja (skok)
		else if (characterControler.isGrounded && Input.GetButton("Jump")) {
			aktualnaWysokoscSkoku = wysokoscSkoku;
		}
		else if (!characterControler.isGrounded) {//Jezeli jestesmy w powietrzu(skok)
												  //Fizyka odpowiadająca za grawitacje (os Y).
			aktualnaWysokoscSkoku += Physics.gravity.y * Time.deltaTime;
		}
		else if (characterControler.isGrounded && !Input.GetButton("Jump"))
		{
			aktualnaWysokoscSkoku = 0;
		}

		if (aktualnaWysokoscSkoku < -50)
        {
			zlamanaNoga = true;
		}			

		//Debug.Log (Physics.gravity.y);

		//Jeżeli noga złamana to niemoże biegać
		if (zlamanaNoga == false)
		{
			//Bieganie
			if (Input.GetKeyDown("left shift"))
			{
				predkoscPoruszania += predkoscBiegania;
			}
			else if (Input.GetKeyUp("left shift"))
			{
				predkoscPoruszania -= predkoscBiegania;
			}
		}
        else
        {
			//powiadomienie że złamana noga
		}

		//Tworzymy wektor odpowiedzialny za ruch.
		//rochLewoPrawo - odpowiada za ruch lewo/prawo,
		//aktualnaWysokoscSkoku - odpowiada za ruch góra/dół,
		//rochPrzodTyl - odpowiada za ruch przód/tył.
		Vector3 ruch = new Vector3(rochLewoPrawo, aktualnaWysokoscSkoku, rochPrzodTyl);
		//Aktualny obrót gracza razy kierunek w którym sie poruszamy (poprawka na obrót myszką abyśmy szli w kierunku w którym patrzymy).
		ruch = transform.rotation * ruch;
		
		characterControler.Move(ruch * Time.deltaTime);
	}

	/**
	 * Metoda odpowiedzialna za ruch myszką.
	 */
	private void myszka(){
		//Pobranie wartości ruchu myszki lewo/prawo.
		// jeżeli wartość dodatnia to poruszamy w prawo,
		// jeżeli wartość ujemna to poruszamy w lewo.
		float myszLewoPrawo = Input.GetAxis("Mouse X") * czuloscMyszki;	
		transform.Rotate(0, myszLewoPrawo, 0);
		
		//Pobranie wartości ruchu myszki góra/dół.
		// jeżeli wartość dodatnia to poruszamy w górę,
		// jeżeli wartość ujemna to poruszamy w dół.
		myszGoraDol -= Input.GetAxis("Mouse Y") * czuloscMyszki;
		
		//Funkcja nie pozwala aby wartość przekroczyła dane zakresy.
		myszGoraDol = Mathf.Clamp(myszGoraDol, -zakresMyszyGoraDol, zakresMyszyGoraDol);
		//Ponieważ CharacterController nie obraca się góra/dół obracamy tylko kamerę.
		Camera.main.transform.localRotation = Quaternion.Euler(myszGoraDol, 0, 0);
	}

}
