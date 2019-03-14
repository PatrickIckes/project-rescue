using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [SerializeField]
    private string displayText = nameof(InteractiveObject);

    private AudioSource audioSource;
    public string DisplayText => displayText;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch
        {
            throw new System.Exception("Missing AudioSource component: InteractiveObject requires an AudioSource component.");
        }

        Debug.Log($"Player interacted with: {gameObject.name}");
    }
}
