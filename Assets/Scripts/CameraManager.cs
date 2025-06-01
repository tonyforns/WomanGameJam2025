using UnityEngine;
using System.Collections.Generic;

public class CameraManager : MonoBehaviour
{
    public enum Personaje
    {
        Eva,
        JuanaDeArco,
        MadamCurie
    }

    [System.Serializable]
    public struct CamaraPorPersonaje
    {
        public Personaje personaje;
        public Camera camara;
    }

    [SerializeField]
    private CamaraPorPersonaje[] camarasConfiguradas;

    private Dictionary<Personaje, Camera> camarasDict;

    private void Awake()
    {
        camarasDict = new Dictionary<Personaje, Camera>();

        foreach (var config in camarasConfiguradas)
        {
            if (config.camara != null && !camarasDict.ContainsKey(config.personaje))
            {
                camarasDict.Add(config.personaje, config.camara);
            }
        }

        // Opcional: desactiva todas las cámaras al inicio
        DesactivarTodasLasCamaras();
    }

    public void CambiarCamara(Personaje personaje)
    {
        if (!camarasDict.ContainsKey(personaje))
        {
            Debug.LogWarning("No hay cámara asignada para el personaje: " + personaje);
            return;
        }

        DesactivarTodasLasCamaras();

        camarasDict[personaje].gameObject.SetActive(true);
    }

    private void DesactivarTodasLasCamaras()
    {
        foreach (var cam in camarasDict.Values)
        {
            if (cam != null)
                cam.gameObject.SetActive(false);
        }
    }
}
