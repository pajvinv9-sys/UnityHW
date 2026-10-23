using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TakeDamageLogicWithVignete : TakeDamageLogicBase
{
    [SerializeField] private Volume volume;
    [SerializeField, Range(0f, 1f)] private float maxIntensity = 0.4f;
    [SerializeField] private float fadeInSpeed = 2f;
    [SerializeField] private float fadeOutSpeed = 1f;

    private Vignette vignette;
    private Coroutine vignetteCoroutine;

    private void Awake()
    {
        if (volume == null)
        {
            Debug.LogError("Volume не назначен!", this);
            return;
        }

        if (volume.profile == null ||
            !volume.profile.TryGet(out vignette))
        {
            Debug.LogError("Vignette не найдена в Volume Profile!", this);
            return;
        }

        vignette.intensity.Override(0f);
    }

    public override void Do(HealthClass healthClass, float damage)
    {
        if (vignette == null)
            return;

        if (vignetteCoroutine != null)
            StopCoroutine(vignetteCoroutine);

        vignetteCoroutine = StartCoroutine(VignetteEffect());
    }

    private IEnumerator VignetteEffect()
    {
        // Плавное появление
        while (vignette.intensity.value < maxIntensity)
        {
            vignette.intensity.value = Mathf.MoveTowards(
                vignette.intensity.value,
                maxIntensity,
                fadeInSpeed * Time.deltaTime
            );

            yield return null;
        }

        // Плавное исчезновение
        while (vignette.intensity.value > 0f)
        {
            vignette.intensity.value = Mathf.MoveTowards(
                vignette.intensity.value,
                0f,
                fadeOutSpeed * Time.deltaTime
            );

            yield return null;
        }

        vignette.intensity.value = 0f;
        vignetteCoroutine = null;
    }
}