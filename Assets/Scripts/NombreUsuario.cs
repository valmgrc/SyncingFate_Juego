using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class NombreUsuario : MonoBehaviour
{
    public TMP_InputField inputName;
    public GameObject confirmButton;

    public void ConfirmName()
    {
        GameData.playerName = inputName.text;

        GameData.Save();

        SceneManager.LoadScene("InicioTutorial");

        
    }
}
