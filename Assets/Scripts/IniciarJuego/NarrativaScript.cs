using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrativaScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        GameData.Load();


        if (!GameData.didCustomization)
        {
            
        }
        else
        {
           
            SceneManager.LoadScene("InicioInicio");
        }

    }



    


    public void BotonSaltar()
    {

        SceneManager.LoadScene("InicioInicio");
    }


   

}
