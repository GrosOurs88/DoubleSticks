using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class WeaponsManager : MonoBehaviour
{
    private InputSystemManager inputSystemManager;
    public GameObject leftVisor = null;
    public GameObject rightVisor = null;
    public float visorsSpeed = 20.0f;

    [HideInInspector] public float screenWidth;
    [HideInInspector] public float screenHeight;

    public float minFusionDistance = 2.0f;
    public float maxUnfusionDistance = 4.5f;
    public Color fusionnedVisorsColor = Color.black;
    private Color leftVisorColor = Color.white;
    private Color rightVisorColor = Color.white;
    public Vector3 fusionnedVisorsScale = new Vector3(1.75f, 1.75f, 1.75f);
    private Vector3 leftVisorScale = Vector3.one;
    private Vector3 rightVisorScale = Vector3.one;
    public string fusionnedVisorsTag = "FusionnedVisor";
    public string leftVisorTag = "LeftVisor"; //private
    public string rightVisorTag = "RightVisor"; //private
    private bool areVisorsFusionned = false;

    public static WeaponsManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        inputSystemManager = InputSystemManager.instance;

        RegisterVisorsValues();
    }

    void Update()
    {
        //Move visors
        if (inputSystemManager.LeftStick.ReadValue<Vector2>().magnitude != 0)
        {
            MoveVisor(leftVisor, inputSystemManager.LeftStick.ReadValue<Vector2>());
            ClampVisorPosition(leftVisor);
        }
        if (inputSystemManager.rightStick.ReadValue<Vector2>().magnitude != 0)
        {
            MoveVisor(rightVisor, inputSystemManager.rightStick.ReadValue<Vector2>());
            ClampVisorPosition(rightVisor);
        }

        //Fusion visors
        if (areVisorsFusionned == false && Vector3.Distance(leftVisor.transform.position, rightVisor.transform.position) < minFusionDistance)
        {
            FusionVisors();
            areVisorsFusionned = true;
        }

        //Unfusion visors
        if (areVisorsFusionned == true && Vector3.Distance(leftVisor.transform.position, rightVisor.transform.position) > maxUnfusionDistance)
        {
            UnfusionVisors();
            areVisorsFusionned = false;
        }

        //if (InputSystem.instance.rightTrigger.ReadValue<float>() > 0f) //scroll forward
        //{
        //    CamerasBaseScript.instance.activeCamera.GetComponent<Camera>().fieldOfView -= zoomSensitivity * Time.deltaTime;
        //}
    }

    private void MoveVisor(GameObject _object, Vector2 _vector2)
    {
        _object.transform.position += new Vector3(_vector2.x, _vector2.y, _object.transform.position.z) * visorsSpeed * Time.deltaTime;
    }

    private void ClampVisorPosition(GameObject _object)
    {
        //CLAMP FOR SCREEN SPACE CAMERA - Auto update if resolution changes
        screenWidth = (Screen.currentResolution.width * Camera.main.orthographicSize) / Screen.currentResolution.height;
        screenHeight = Camera.main.orthographicSize;

        _object.transform.position = new Vector3(Mathf.Clamp(_object.transform.position.x, -screenWidth, screenWidth),
                                                 Mathf.Clamp(_object.transform.position.y, -screenHeight, screenHeight),
                                                _object.transform.position.z);


        //CLAMP FOR SCREEN SPACE OVERLAY
        //_object.transform.position = new Vector3(Mathf.Clamp(_object.transform.position.x, 0, Screen.currentResolution.width),
        //                                         Mathf.Clamp(_object.transform.position.y, 0, Screen.currentResolution.height),
        //                                        _object.transform.position.z);        
    }

    private void RegisterVisorsValues()
    {
        leftVisorColor = leftVisor.GetComponent<Image>().color;
        rightVisorColor = rightVisor.GetComponent<Image>().color;

        leftVisorScale = leftVisor.GetComponent<RectTransform>().localScale;
        rightVisorScale = rightVisor.GetComponent<RectTransform>().localScale;

        leftVisorTag = leftVisor.tag;
        rightVisorTag = rightVisor.tag;
    }

    private void FusionVisors()
    {
        leftVisor.GetComponent<Image>().color = fusionnedVisorsColor;
        rightVisor.GetComponent<Image>().color = fusionnedVisorsColor;

        leftVisor.GetComponent<RectTransform>().localScale = fusionnedVisorsScale;
        rightVisor.GetComponent<RectTransform>().localScale = fusionnedVisorsScale;

        leftVisor.tag = fusionnedVisorsTag;
        rightVisor.tag = fusionnedVisorsTag;
    }

    private void UnfusionVisors()
    {
        leftVisor.GetComponent<Image>().color = leftVisorColor;
        rightVisor.GetComponent<Image>().color = rightVisorColor;

        leftVisor.GetComponent<RectTransform>().localScale = leftVisorScale;
        rightVisor.GetComponent<RectTransform>().localScale = rightVisorScale;

        leftVisor.tag = leftVisorTag;
        rightVisor.tag = rightVisorTag;
    }

    private void Print()
    {
        print(leftVisor.name + " Transform: " + leftVisor.transform.position);
        print(leftVisor.name + " RectTransform Local " + leftVisor.GetComponent<RectTransform>().localPosition);

        print("Scereen Height: " + Screen.height);
        print("Scereen Width: " + Screen.width);
    }
}
