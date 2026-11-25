using UnityEngine;
using UnityEngine.UI;

public class MetricsUI : MonoBehaviour
{
    public Text validacionText;
    public Text vinculosText;
    public Text autoText;

    void Start()
    {
        Update();
    }

   

    void Update()
    {
        validacionText.text = "Validación: " + GameData.validacion;
        vinculosText.text = "Vínculos: " + GameData.vinculos;
        autoText.text = "Auto: " + GameData.autopercepcion;
    }
}