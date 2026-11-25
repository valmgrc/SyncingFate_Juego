using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalesController : MonoBehaviour
{
    public GameObject finalBueno;
    public GameObject finalMalo;

    void Start()
    {
        int endingType = PlayerPrefs.GetInt("EndingType", 0);

        // Promedio >= 50 → final bueno; < 50 → final malo
        if (endingType == 1)
        {
            finalBueno.SetActive(true);
            finalMalo.SetActive(false);
        }
        else
        {
            finalBueno.SetActive(false);
            finalMalo.SetActive(true);
        }
    }

    /// <summary>Reinicia toda la partida y vuelve al inicio.</summary>
    public void Jugar()
    {
        GameData.ResetData();
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("InicioInicio");
    }

    /// <summary>Cierra la aplicación.</summary>
    public void Salir()
    {
        Application.Quit();
    }
}
