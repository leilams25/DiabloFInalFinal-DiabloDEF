using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations;

public class NPC : MonoBehaviour
{
    [SerializeField] private float duracionRotacion;
    [SerializeField] private DialogoSo miDialogo;
    [SerializeField] private Transform cameraPoint;

    internal void Interactuar(Transform interactuador)
    {
        
        transform.DOLookAt(interactuador.position, duracionRotacion, AxisConstraint.Y).OnComplete(IniciarInteraccion);
    }
    private void IniciarInteraccion()
    {
        SistemaDialogo.sistema.IniciarDialogo(miDialogo, cameraPoint);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
