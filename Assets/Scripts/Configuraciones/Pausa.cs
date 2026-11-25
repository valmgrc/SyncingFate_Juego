using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    public GameObject Panel;
    
    public GameObject PanelMetrica1;
    public GameObject PanelMetrica2;
    public GameObject PanelMetrica3;


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
    public void InfoMetricas1On()
    {

        PanelMetrica1.SetActive(true);
    }
    public void InfoMetricas2On()
    {

        PanelMetrica2.SetActive(true);
    }
    public void InfoMetricas3On()
    {

        PanelMetrica3.SetActive(true);
    }



    public void InfoMetricas1Off()
    {

        PanelMetrica1.SetActive(false);
    }

    public void InfoMetricas2Off()
    {

        PanelMetrica2.SetActive(false);
    }
    public void InfoMetricas3Off()
    {

        PanelMetrica3.SetActive(false);
    }




}
