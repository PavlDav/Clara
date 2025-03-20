using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateBloodParticlesOnGrab : MonoBehaviour
{
    public ParticleSystem bloodParticles; // Référence au système de particules de sang
    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable; // Référence à l'objet interactif (à saisir)

    void Start()
    {
        // Récupère le composant XRGrabInteractable de l'objet auquel ce script est attaché
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

        // Vérifie si grabInteractable existe
        if (grabInteractable != null)
        {
            // Ajoute un écouteur à l'événement de saisie avec la méthode mise à jour
            grabInteractable.selectEntered.AddListener(ActivateBloodParticles);
        }
    }

    // Cette fonction est appelée quand l'objet est saisi
    void ActivateBloodParticles(SelectEnterEventArgs args)
    {
        // Joue les particules de sang
        if (bloodParticles != null)
        {
            bloodParticles.Play(); // Joue l'effet de particules de sang
        }
    }

    // Retirer l'écouteur quand l'objet est détruit
    void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(ActivateBloodParticles);
        }
    }
}
