// Copyright (c) 2012-2024 FuryLion Group. All Rights Reserved.

using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _recordsButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _exitButton;
    
    public override void Initialize()
    {
        _playButton.onClick.AddListener(OnPlayButtonClicked);
        _recordsButton.onClick.AddListener(() => ViewManager.Show<RecordsMenuView>());
        _settingsButton.onClick.AddListener(() => ViewManager.Show<SettingsMenuView>());
        _exitButton.onClick.AddListener(() => ViewManager.Show<ExitMenuView>());
    }

    private void OnPlayButtonClicked()
    {
        ViewManager.LoadSceneGame();
    }
}