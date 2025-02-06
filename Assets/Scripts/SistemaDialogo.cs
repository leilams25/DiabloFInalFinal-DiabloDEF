using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo sistema;
    // Start is called before the first frame update
    void Start()
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


    public void IniciarDialogo()
    {


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
