using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class WeaponsManager : MonoBehaviour
{
    private InputSystemManager inputSystemManager;
    public GameObject leftVisor = null;
    public GameObject rightVisor = null;
    public float visorsSpeed = 5.0f;

    void Start()
    {
        inputSystemManager = InputSystemManager.instance;
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
        _object.transform.position = new Vector3(Mathf.Clamp(_object.transform.position.x, 0, Screen.currentResolution.width),
                                                 Mathf.Clamp(_object.transform.position.y, 0, Screen.currentResolution.height),
                                                _object.transform.position.z);

        print(_object.name + " " + _object.transform.position);
    }
}
