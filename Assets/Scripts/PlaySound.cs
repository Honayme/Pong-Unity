using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{
    public Button button = null;
    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (button != null)
            button.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnButtonClick()
    {
        if (audioSource != null)
            audioSource.Play();
    }
}