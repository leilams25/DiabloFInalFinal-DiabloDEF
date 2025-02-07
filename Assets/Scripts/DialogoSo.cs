using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Diálogo")]
public class DialogoSo : ScriptableObject

       
{
    [TextArea(3,5)]
   public string[] frases;
   public float tiempoEntreLetras;
}
