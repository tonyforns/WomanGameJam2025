using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraTransition : MonoBehaviour
{
    public Image fadeImage; // Una imagen negra en pantalla completa
    public float fadeDuration = 1f;
    public CameraManager cameraManager;

    public void TransicionarACamara(CameraManager.Personaje personaje)
    {
        StartCoroutine(FadeAndSwitch(personaje));
    }

    private IEnumerator FadeAndSwitch(CameraManager.Personaje personaje)
    {
        yield return StartCoroutine(Fade(1)); // Fundido a negro
        cameraManager.CambiarCamara(personaje);
        yield return StartCoroutine(Fade(0)); // Fundido desde negro
    }

    private IEnumerator Fade(float targetAlpha)
    {
        Color color = fadeImage.color;
        float startAlpha = color.a;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, t / fadeDuration);
            color.a = alpha;
            fadeImage.color = color;
            yield return null;
        }

        color.a = targetAlpha;
        fadeImage.color = color;
    }
}
