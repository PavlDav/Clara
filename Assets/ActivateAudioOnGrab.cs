using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateAudioOnGrab : MonoBehaviour
{
    public AudioClip grabSound; // Référence au son de saisie
    public AudioClip releaseSound; // Référence au son de relâchement
    private AudioSource audioSource; // Référence à l'AudioSource

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // Référence à l'objet interactif (à saisir)

    void Start()
    {
        // Récupère le composant XRGrabInteractable de l'objet
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        
        // Récupère le composant AudioSource de l'objet
        audioSource = GetComponent<AudioSource>();

        // Vérifie si grabInteractable existe
        if (grabInteractable != null)
        {
            // Ajoute un écouteur à l'événement de saisie
            grabInteractable.selectEntered.AddListener(PlayGrabSound);

            // Ajoute un écouteur à l'événement de relâchement de l'objet
            grabInteractable.selectExited.AddListener(PlayReleaseSound);
        }
    }

    // Cette fonction est appelée quand l'objet est saisi
    void PlayGrabSound(SelectEnterEventArgs args)
    {
        if (grabSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(grabSound); // Joue le son de saisie
        }
    }

    // Cette fonction est appelée quand l'objet est relâché
    void PlayReleaseSound(SelectExitEventArgs args)
    {
        if (releaseSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(releaseSound); // Joue le son de relâchement
        }
    }

    // Retirer l'écouteur quand l'objet est détruit
    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(PlayGrabSound);
            grabInteractable.selectExited.RemoveListener(PlayReleaseSound);
        }
    }
}
