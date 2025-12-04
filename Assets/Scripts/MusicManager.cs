using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    public AudioClip menuMusic;
    public AudioClip gameplayMusic;
    public AudioClip deathMusic;
    public AudioClip finalMusic;

    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "Menu":
                PlayMusic(menuMusic, true);
                break;

            case "Inici":  
                PlayMusic(menuMusic, true);
                break;

            case "Fi":
                PlayMusic(deathMusic, false);
                break;
        }
    }
    public void playGameplayMusic()
    {
        PlayMusic(gameplayMusic, true);
    }
    public void PlayFinalMusic()
    {
        PlayMusic(finalMusic, false);
    }

    void PlayMusic(AudioClip clip, bool loop)
    {
        if (audioSource.clip == clip) return;

        audioSource.loop = loop;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
