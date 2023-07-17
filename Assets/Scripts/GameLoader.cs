using UnityEngine;
using IJunior.TypedScenes;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private Transition _transition;

    public void LoadMenu()
    {
        _transition.On();
        MainMenu.Load();
    }

    public void LoadGame()
    {
        Game.Load();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
