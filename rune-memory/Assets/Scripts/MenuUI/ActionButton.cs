/// Created by Hellen Caroline Salvato - Project Memory Runes (2022)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// General action buttons behavior
/// </summary>
namespace MenuUI
{
    [RequireComponent(typeof(Button))]
    public class ActionButton : MonoBehaviour
    {
        public string action = "null";
        private Button button;
        private void Start()
        {
            button = this.gameObject.GetComponent<Button>();
            button.onClick.AddListener(DeleteSave);
        }

        public void DeleteSave()
        {
            PlayerPrefs.DeleteAll();
            MenuUI.ScenesManager.Instance.ReloadScene();
        }
    }
}