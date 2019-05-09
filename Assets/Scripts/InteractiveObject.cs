using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Used on variouis object to enable them for interactivity and use in game.
/// </summary>

[RequireComponent (typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("Text that will display in the UI when the player looks at this object in the world.")]
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    [SerializeField]
    private string gameSceneName;

    protected AudioSource audioSource;
    public virtual string DisplayText => displayText;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
            SceneManager.LoadScene(gameSceneName);
        }
        catch
        {
            throw new System.Exception("Missing AudioSource component: InteractiveObject requires an AudioSource component with an AudioSource clip assigned.");
        }

        Debug.Log($"Player interacted with: {gameObject.name}");
    }
}