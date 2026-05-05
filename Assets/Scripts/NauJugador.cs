using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NauJugador : MonoBehaviour
{
    private float _vel;

    public GameObject _ExplosioPrefab;

    public GameManager _gameManager;

    void Start()
    {
        _vel = 8f;
    }

    void Update()
    {
        float direccioInputX = Input.GetAxisRaw("Horizontal");
        float direccioInputY = Input.GetAxisRaw("Vertical");

        Vector2 direccioIndicada = new Vector2(direccioInputX, direccioInputY).normalized;

        MoureNau(direccioIndicada);
    }

    void MoureNau(Vector2 direccioIndicada)
    {
        Vector2 posNau = transform.position;

        posNau = posNau + direccioIndicada * _vel * Time.deltaTime;

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        maxPantalla.x = maxPantalla.x - 0.6f;
        minPantalla.x = minPantalla.x + 0.6f;
        maxPantalla.y = maxPantalla.y - 0.8f;
        minPantalla.y = minPantalla.y + 0.8f;

        posNau.x = Mathf.Clamp(posNau.x, minPantalla.x, maxPantalla.x);
        posNau.y = Mathf.Clamp(posNau.y, minPantalla.y, maxPantalla.y);

        transform.position = posNau;
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Enemic" || objecteTocat.tag == "ProjectilEnemic")
        {
            GameObject explosio = Instantiate(_ExplosioPrefab);
            explosio.transform.position = transform.position;

            ValorsGlobals.videsJugador--;

            GameObject textVides = GameObject.Find("LivesText");
            if (textVides != null)
            {
                TextVidesJugador tvj = textVides.GetComponent<TextVidesJugador>();
                if (tvj != null) tvj.ActualitzarVides();
            }

            if (ValorsGlobals.videsJugador <= 0)
            {
                SceneManager.LoadScene("EscenaResultats");
            }
        }
    }
}
