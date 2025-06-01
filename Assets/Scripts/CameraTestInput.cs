using UnityEngine;

public class CameraTestInput : MonoBehaviour
{
    public CameraTransition cameraTransition;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            cameraTransition.TransicionarACamara(CameraManager.Personaje.Eva);
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            cameraTransition.TransicionarACamara(CameraManager.Personaje.JuanaDeArco);
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            cameraTransition.TransicionarACamara(CameraManager.Personaje.MadamCurie);
    }
}
