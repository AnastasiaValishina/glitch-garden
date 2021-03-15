using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 0;

    MusicPlayer musicPlayer;
    void Start()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();

        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();

        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        difficultySlider.onValueChanged.AddListener(delegate { OnDifficultyChanged(); });
    }

    void OnVolumeChanged()
    {
        if (musicPlayer)

        {

            musicPlayer.SetVolume(volumeSlider.value);

        }

        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
    }

    void OnDifficultyChanged()
    {
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
