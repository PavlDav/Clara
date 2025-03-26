using UnityEngine;
using UnityEngine.SceneManagement;

public class changement : MonoBehaviour
{
    public static string buttonClickedName; // Variable statique pour stocker le nom du bouton

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ButtonClicked(string buttonName)
    {
        buttonClickedName = buttonName; // Stocke le nom du bouton
        SceneManager.LoadScene("ExamenRoom");
    }
}

