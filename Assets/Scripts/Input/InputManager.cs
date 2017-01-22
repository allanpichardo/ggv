using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

        private HashSet<InputListener> listeners = new HashSet<InputListener>();

        void Awake() {

        }

        public interface InputListener {
            void OnButtonPressed(string keyName, int milliseconds);
        }

        void Update() {
            if(Input.GetKeyDown(KeyCode.Space)){
                foreach(InputListener listener in listeners){
                    listener.OnButtonPressed("space", DateTime.Now.Millisecond);
                }
            }
        }

        public void AddInputListener(InputListener listener) {
            listeners.Add(listener);
        }

    }