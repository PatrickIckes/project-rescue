using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used on variouis object to enable them for interactivity and use in game.
/// </summary>

[RequireComponent (typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

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
        }
        catch
        {
            throw new System.Exception("Missing AudioSource component: InteractiveObject requires an AudioSource component with an AudioSource clip assigned.");
        }

        Debug.Log($"Player interacted with: {gameObject.name}");
    }
}