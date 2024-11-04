// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InteractiveController : MonoBehaviour
{
    [SerializeField] private Button next1Button;
    [SerializeField] private Button next2Button;
    [SerializeField] private Button next3Button;
    
    private void Awake()
    {
        next1Button.onClick.AddListener(OnNext1ButtonClicked);
        next2Button.onClick.AddListener(OnNext2ButtonClicked);
        next3Button.onClick.AddListener(OnNext3ButtonClicked);
    }

    private void OnNext1ButtonClicked()
    {
        ViewManager.Show<Interactive2View>();
    }

    private void OnNext2ButtonClicked()
    {
        ViewManager.Show<Interactive3View>();
    }
    
    private void OnNext3ButtonClicked()
    {
        ViewManager.LoadSceneMenu();
    }
}