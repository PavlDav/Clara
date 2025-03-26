using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabPointSystem : MonoBehaviour
{
    public int pointsPerGrab = 10;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;
    private ScoreManager scoreManager;

    private void Awake()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        scoreManager = FindObjectOfType<ScoreManager>();

        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        Debug.Log($"Objet saisi par : {args.interactorObject.transform.gameObject.name}");
        if (scoreManager != null)
        {
            scoreManager.AddPoints(pointsPerGrab);
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}
