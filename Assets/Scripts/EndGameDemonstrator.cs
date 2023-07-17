using TMPro;
using UnityEngine;

public class EndGameDemonstrator : MonoBehaviour
{
    [SerializeField] private Referee _referee;
    [SerializeField] private MainText _mainText;
    [SerializeField] private Canvas _mainGameCanvas;
    [SerializeField] private Canvas _endGameCanvas;
    [SerializeField] private TMP_Text _endGameDescription;
    [SerializeField] private TMP_Text _endGameHeading;

    private void OnEnable()
    {
        _referee.IsLose += DemonstrateLose;
        _referee.IsWin += DemonstrateWin;
    }

    private void OnDisable()
    {
        _referee.IsLose -= DemonstrateLose;
        _referee.IsWin -= DemonstrateWin;
    }

    private void DemonstrateLose()
    {
        ConfigureEndGameCanvas("Не в этот раз");
        ShowEndGameCanvas();
    }

    private void DemonstrateWin()
    {
        ConfigureEndGameCanvas("Победа!");
        ShowEndGameCanvas();
    }

    private void ShowEndGameCanvas()
    {
        _mainGameCanvas.gameObject.SetActive(false);
        _endGameCanvas.gameObject.SetActive(true);
    }

    private void ConfigureEndGameCanvas(string gameHeadingText)
    {
        _endGameHeading.text = gameHeadingText;
        _mainText.SwapMainTextObject(_endGameDescription);
    }
}
