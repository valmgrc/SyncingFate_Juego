using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpcionesPersonalizacion : MonoBehaviour
{
    

    public void Siguiente(string CreacionPersonaje2)
    {
        SceneManager.LoadScene(CreacionPersonaje2);
    }

}