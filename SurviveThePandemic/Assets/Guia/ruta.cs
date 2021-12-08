using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ruta : MonoBehaviour
{
    //Información de la Misión
    [Header("Title and Description")]
    public string missionTitle;
    public Text missionTitleText;
    public string missionDescription;
    public Text missionDescriptionText;
    public string missionComplete = "";
    public Text missionCompleteText;
    public GameObject completeUI;

    [Header("Trigger Settings")]
    //Objetivos Anteriores y Siguientes
    public GameObject actualMission;
    public GameObject nextMission;
    public float delay;

    [Header("Indicator Settings")]
    public Camera mainCamera;
    private RectTransform m_icon;
    private Image m_iconImage;
    public Canvas mainCanvas;
    private Vector3 m_cameraOffsetUp;
    private Vector3 m_cameraOffsetRight;
    public Sprite m_targetIconOnScreen;
    public Sprite m_targetIconOffScreen;
    public Transform player;
    private Text text_distance;
    private float distance;
    private RectTransform m_distance;
    public Font Fuente;
    public int _fontSize;

    [Space]
    [Range(0, 100)]
    public float m_edgeBuffer;
    public Vector3 m_targetIconScale;
    public Vector3 m_targetDistanceScale;
    public float m_targetDistanceX, m_targetDistanceY;
    [Space]
    public bool PointTarget = true;
    public bool ShowDebugLines;
    //Indica si el objetivo esta fuera de la camara
    private bool m_outOfScreen;

    [Space]
    [Header("Indicators Color")]
    //Colores para los indicadores
    public Color iconTargetColor = new Vector4(1, 1, 1, 1);
    public Color distanceTargetColor = new Vector4(1, 1, 1, 1);

    //Inicio Script
    void Start()
    {
        mainCamera = Camera.main;
        mainCanvas = FindObjectOfType<Canvas>();
        Debug.Assert((mainCanvas != null), "Asigna Canvas para Funcionar");
        InstainateTargetIcon();
    }
    //Update for Frames
    void Update()
    {
        if (player)
        {
            text_distance.text = distance.ToString("0") + " Mts";
            distance = Vector3.Distance(player.position, transform.position);
        }
        UpdateTargetIconPosition();

        missionTitleText.text = missionTitle;
        missionDescriptionText.text = missionDescription;
        missionCompleteText.text = missionComplete;
    }
    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            completeUI.SetActive(true);
            Destroy(m_iconImage);
            Destroy(text_distance);
            yield return new WaitForSeconds(delay);
            actualMission.SetActive(false);
            nextMission.SetActive(true);
            completeUI.SetActive(false);
        }
    }
    private void InstainateTargetIcon()
    {
        //Funciones para la instancia de los sprites, textos y colores
        m_icon = new GameObject().AddComponent<RectTransform>();
        m_icon.transform.SetParent(mainCanvas.transform);
        m_icon.localScale = m_targetIconScale;
        m_icon.name = name + ": Indicator";
        m_iconImage = m_icon.gameObject.AddComponent<Image>();
        m_iconImage.sprite = m_targetIconOnScreen;
        m_iconImage.gameObject.GetComponent<Image>().color = iconTargetColor;
        m_distance = new GameObject().AddComponent<RectTransform>();
        m_distance.transform.SetParent(m_iconImage.transform);
        m_distance.localScale = m_targetDistanceScale;
        m_distance.name = name + ": distance";
        RectTransform rt = m_distance.GetComponent(typeof(RectTransform)) as RectTransform;
        rt.sizeDelta = new Vector2(300, 100);
        m_distance.anchoredPosition = new Vector2(m_targetDistanceX, m_targetDistanceY);
        text_distance = m_distance.gameObject.AddComponent<Text>();
        text_distance.alignment = TextAnchor.MiddleCenter;
        text_distance.gameObject.GetComponent<Text>().font = Fuente;
        text_distance.gameObject.GetComponent<Text>().fontSize = _fontSize;
        text_distance.text = text_distance.text = distance.ToString("0") + " Mts";
        distance = Vector3.Distance(player.position, transform.position);
        text_distance.gameObject.GetComponent<Text>().color = distanceTargetColor;
    }
    private void UpdateTargetIconPosition()
    {
        Vector3 newPos = transform.position;
        newPos = mainCamera.WorldToViewportPoint(newPos);
        //Chequear si el objetivo esta dentro o fuera de la pantalla
        if (newPos.x > 1 || newPos.y > 1 || newPos.x < 0 || newPos.y < 0)
            m_outOfScreen = true;
        else
            m_outOfScreen = false;
        if (newPos.z < 0)
        {
            newPos.x = 1f - newPos.x;
            newPos.y = 1f - newPos.y;
            newPos.z = 0;
            newPos = Vector3Maxamize(newPos);
        }
        newPos = mainCamera.ViewportToScreenPoint(newPos);
        newPos.x = Mathf.Clamp(newPos.x, m_edgeBuffer, Screen.width - m_edgeBuffer);
        newPos.y = Mathf.Clamp(newPos.y, m_edgeBuffer, Screen.height - m_edgeBuffer);
        m_icon.transform.position = newPos;
        //Operaciones por si el objetivo esta por fuera de la pantalla
        if (m_outOfScreen)
        {
            //Icono OffScreen
            m_iconImage.sprite = m_targetIconOffScreen;
            if (PointTarget)
            {
                //Rota el icono alrededor de la pantalla
                var targetPosLocal = mainCamera.transform.InverseTransformPoint(transform.position);
                var targetAngle = -Mathf.Atan2(targetPosLocal.x, targetPosLocal.y) * Mathf.Rad2Deg - 360;
                //Aplica Rotación
                m_icon.transform.eulerAngles = new Vector3(0, 0, targetAngle);
            }
        }
        else
        {
            //Resetea la rotacion a cero
            m_icon.transform.eulerAngles = new Vector3(0, 0, 0);
            m_iconImage.sprite = m_targetIconOnScreen;
        }
    }
    public Vector3 Vector3Maxamize(Vector3 vector)
    {
        Vector3 returnVector = vector;
        float max = 0;
        max = vector.x > max ? vector.x : max;
        max = vector.y > max ? vector.y : max;
        max = vector.z > max ? vector.z : max;
        returnVector /= max;
        return returnVector;
    }
}
