using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaResultats : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI puntsAconseguits;

    [SerializeField]
    private TMPro.TextMeshProUGUI videsAgafades;

    void Start()
    {
        puntsAconseguits.text = ValorsGlobals.puntsAconseguits;
        videsAgafades.text = "Vides agafades: " + ValorsGlobals.videsAgafades;
    }

    void Update()
    {
    }

    public void TornarAInici()
    {
        
        SceneManager.LoadScene("EscenaInici");
    }


}
