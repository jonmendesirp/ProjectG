using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //chama o UI para o volume slider funcionar

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }

        else
        {
            Load();
        }
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value; //para a altera��o no slider ser correspondente � altera��o no volume
        Save(); //salvar o volume
    }
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume"); //dar load �s preferencias do jogador
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value); //salvar o valor do volume
    }


}
