using UnityEngine;
using UnityEngine.SceneManagement;


public class JugarBotones : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    public void BotonJugar()
    {
        GameData.Load();

       
        if (!GameData.didCustomization)
        {
          
            SceneManager.LoadScene("NarrativaFinal");
        }
        else
        {
           
            SceneManager.LoadScene("PantallaInicio");
        }
    }

    


    public void BotonSalir()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();

        
       
    }

public void BotonInicio()
{
        SceneManager.LoadScene("InicioInicio");

    }
    



}
