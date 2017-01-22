using System;
using UnityEngine;

public class VibeCollision : MonoBehaviour {

    AudioSource audioSource;

    // Use this for initialization
    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter(Collider other) {
        string othersTag = other.gameObject.tag;

        switch (othersTag){
            case "Player":
                Debug.Log("Enter!");
                audioSource.Play();
                break;
            case "VibeSink":
                Debug.Log("Miss!");
                Destroy(this.gameObject);
                break;
        }
    }

    void OnTriggerStay(Collider other) {
            Debug.Log("Stay!");
    }

    void OnTriggerExit(Collider other) {
            Debug.Log("Exit!");
    }
}
