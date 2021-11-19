using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ConfigDialogos : ScriptableObject
{
    public float tiempoLetra = 0.1f;
    public KeyCode teclaSkip = KeyCode.Space;
    public KeyCode teclaSkip2 = KeyCode.JoystickButton3;

    public KeyCode teclaSiguienteFrase = KeyCode.Space;
    public KeyCode teclaInicioDialogo = KeyCode.B;
    public KeyCode teclaInicioDialogo2 = KeyCode.JoystickButton3;    
}
