using UnityEngine;
using UnityEngine.SceneManagement;

public class JugarBotones : MonoBehaviour
{
    public Animator jugarAnim;
    public Animator salirAnim;
    public Animator inicioAnim;


    public void OnHoverEnter(int tipo)
    {
        GetAnimator(tipo).SetBool("isHover", true);
    }

    public void OnHoverExit(int tipo)
    {
        GetAnimator(tipo).SetBool("isHover", false);
    }

    Animator GetAnimator(int t)
    {
        if (t == 1) return jugarAnim;
        if (t == 2) return salirAnim;
        return inicioAnim;
    }


    public void ClickJugar()
    {
        jugarAnim.SetTrigger("isSelected");
        BotonJugar();
    }

    public void ClickSalir()
    {
        salirAnim.SetTrigger("isSelected");
        BotonSalir();
    }

    public void ClickInicio()
    {
        inicioAnim.SetTrigger("isSelected");
        BotonInicio();
    }

  
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