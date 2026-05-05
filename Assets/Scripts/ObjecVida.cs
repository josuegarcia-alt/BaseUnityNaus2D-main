using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjecVida : MonoBehaviour
{
    float _vel = 2.5f;

    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos += Vector2.down * _vel * Time.deltaTime;
        transform.position = novaPos;

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if (transform.position.y < minPantalla.y)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "NauJugador")
        {
            ValorsGlobals.videsJugador++;
            ValorsGlobals.videsAgafades++;

            GameObject textVides = GameObject.Find("LivesText");
            if (textVides != null)
            {
                TextVidesJugador tvj = textVides.GetComponent<TextVidesJugador>();
                if (tvj != null) tvj.ActualitzarVides();
            }

            Destroy(gameObject);
        }
    }
}
