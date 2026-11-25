using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public GameObject Panel;
    public GameObject PanelMetrica;


    void Start ()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }
    
    public void Pausar()
    {

        Panel.SetActive(true);
    }

    public void Reanudar()
    {

        Panel.SetActive(false);
    }

    public void IrInicio()
    {

        SceneManager.LoadScene("InicioInicio");
    }

    public void GuardeySal()
    {
        GameData.Save();
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }


    //funciones para la info de las metricas
    public void InfoMetricasOn()
    {

        PanelMetrica.SetActive(true);
    }

    public void InfoMetricasOff()
    {

        PanelMetrica.SetActive(false);
    }


}
