using UnityEngine;
using UnityEngine.SceneManagement;

public class IrPublicacion : MonoBehaviour
{
    public void PantallaPub(string Publicaciones)
    {
        SceneManager.LoadScene(Publicaciones);
    }
}