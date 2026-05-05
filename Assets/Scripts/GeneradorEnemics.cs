using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorEnemics : MonoBehaviour
{
    public GameObject _NauEnemicPrefab;
    public GameObject _NauEnemicEspecialPrefab;
    public GameObject _ObjecVidaPrefab;

    void Start()
    {
        IniciGeneraEnemics();
    }

    void Update()
    {
    }

    public void IniciGeneraEnemics()
    {
        InvokeRepeating("CreaEnemic", 2f, 1f);
        InvokeRepeating("CreaEnemicEspecial", 5f, 8f);
        InvokeRepeating("CreaObjecVida", 6f, 7f);
    }

    public void AturaGenerarEnemics()
    {
        CancelInvoke("CreaEnemic");
        CancelInvoke("CreaEnemicEspecial");
        CancelInvoke("CreaObjecVida");
    }

    private void CreaEnemic()
    {
        GameObject nauEnemic = Instantiate(_NauEnemicPrefab);

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

        float posicioHoritzontalComponentX = Random.Range(minPantalla.x, maxPantalla.x);
        nauEnemic.transform.position = new Vector2(posicioHoritzontalComponentX, maxPantalla.y);
    }

    private void CreaEnemicEspecial()
    {
        if (_NauEnemicEspecialPrefab == null) return;
        GameObject nauEspecial = Instantiate(_NauEnemicEspecialPrefab);

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

        float posX = Random.Range(minPantalla.x, maxPantalla.x);
        nauEspecial.transform.position = new Vector2(posX, maxPantalla.y);
    }

    private void CreaObjecVida()
    {
        if (_ObjecVidaPrefab == null) return;
        GameObject objecVida = Instantiate(_ObjecVidaPrefab);

        Vector2 minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0f, 0f));
        Vector2 maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1f, 1f));

        float posX = Random.Range(minPantalla.x, maxPantalla.x);
        objecVida.transform.position = new Vector2(posX, maxPantalla.y);
    }
}
