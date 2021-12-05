using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [CreateAssetMenu(fileName = "Conversacion", menuName = "Sistema de Dialogo/Nueva Conversacion")]
    public class Conversación : ScriptableObject {
        [System.Serializable]
        public struct Linea {
            public Personaje personaje;
            [TextArea(3, 5)]
            public string dialogo;
        }
    public bool desbloqueado;
    public bool finalizado;
    public bool reUsar;
    public Linea[] dialogos;

    }
