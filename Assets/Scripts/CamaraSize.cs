using UnityEngine;

public class CamaraSize : MonoBehaviour
{
    void Start()
    {
        ApplyAspect();
    }

    void ApplyAspect()
    {
        float targetAspect = 9f / 16f; // tu juego vertical
        float windowAspect = (float)Screen.width / Screen.height;

        float scale = windowAspect / targetAspect;

        Camera cam = GetComponent<Camera>();

        if (scale < 1.0f)
        {
            // Pantalla más alta → barras arriba/abajo
            Rect rect = cam.rect;
            rect.width = 1;
            rect.height = scale;
            rect.x = 0;
            rect.y = (1 - scale) / 2;
            cam.rect = rect;
        }
        else
        {
            // Pantalla más ancha → barras a los lados (este es tu caso en PC)
            float scaleWidth = 1.0f / scale;

            Rect rect = cam.rect;
            rect.width = scaleWidth;
            rect.height = 1;
            rect.x = (1 - scaleWidth) / 2;
            rect.y = 0;
            cam.rect = rect;
        }
    }
}