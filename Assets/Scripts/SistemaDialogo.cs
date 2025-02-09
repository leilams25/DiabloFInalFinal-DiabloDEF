using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo sistema;
    [SerializeField]  GameObject marcoDialogo; 
    [SerializeField] private TMP_Text textoDialogo;
   

    private bool escribiendo;
    private int indiceFraseActual = 0;

    void Update()
    {

    }

    private DialogoSo dialogoActual;
    // Start is called before the first frame update
    void Awake()
    {
        if (sistema == null)
        {
            sistema = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void IniciarDialogo(DialogoSo dialogo)
    {

        Time.timeScale = 0;
        marcoDialogo.SetActive(true);
        dialogoActual = dialogo;
        StartCoroutine(EscribirFrase());
    }

    public  IEnumerator EscribirFrase()
    {
        escribiendo = true;
        textoDialogo.text = string.Empty;

        char[] fraseEnLetras = dialogoActual.frases[indiceFraseActual].ToCharArray();
        foreach (char letra in fraseEnLetras)
        {
            textoDialogo.text += letra;
            yield return new WaitForSecondsRealtime(dialogoActual.tiempoEntreLetras);

        }
        escribiendo = false; 
    }
    public void CompletarFrase()
    {
        textoDialogo.text = dialogoActual.frases[indiceFraseActual];
        StopAllCoroutines();
        escribiendo = false;
    }

    public void SiguienteFrase()
    {
        if (!escribiendo)
        {
            indiceFraseActual++;
            if (indiceFraseActual < dialogoActual.frases.Length)
            {
                StartCoroutine(EscribirFrase());

            }
            else
            {
                FinalizarDialogo();
            }
        }
        else
        {
            CompletarFrase();
        }



    }
    public void FinalizarDialogo()
    {

        Time.timeScale = 1;
        marcoDialogo.SetActive(false);
        indiceFraseActual = 0;
        escribiendo = false;
        dialogoActual = null;

    }
   
   
}
