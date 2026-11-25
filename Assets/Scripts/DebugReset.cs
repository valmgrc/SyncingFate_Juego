using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Limpia todos los PlayerPrefs y reinicia el juego al presionar Ctrl+Shift+R.
/// Adjunta este script a cualquier GameObject persistente (ej. en InicioInicio).
/// </summary>
public class DebugReset : MonoBehaviour
{
    private const KeyCode ResetKey = KeyCode.R;

    void Update()
    {
        bool ctrlHeld = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        bool shiftHeld = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        if (ctrlHeld && shiftHeld && Input.GetKeyDown(ResetKey))
        {
            GameData.ResetAll();
            SceneManager.LoadScene(0);
        }
    }
}
