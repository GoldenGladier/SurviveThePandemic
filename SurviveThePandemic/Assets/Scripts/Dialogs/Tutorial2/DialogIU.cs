using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogIU : MonoBehaviour
{
   public Conversacion conversacion
   [SerializableField]
        private float textSpeed = 10;

    [SerializableField]
    private GameObject convContainer;
    [SerializableField]
    private GameObject pregContainer;

    [SerializableField]
    private Image speakIm;
    [SerializableField]
    private textMeshProUGUI nombre;
    [SerializableField]
    private textMeshProUGUI convText;

    [SerializableField]
    private Button continuarButton;
    [SerializableField]
    private Button anteriorButton;

    public int localIn = 1;

    private void Start() {
        convContainer.SetActive(true);
        pregContainer.SetActive(false);

        siguienteButton.gameObjectSetActive(true);
        anteriorButton.gameObjectSetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ActualizarTextos(1);

        }

    }

    public void ActualizarTextos(int comportamiento)
    {
        convContainer(true);
        switch (comportamiento)
        {
            case -1:
                if (localIn > 0)
                {
                    print("Dialogo anterior");
                }
        }
    }
}
