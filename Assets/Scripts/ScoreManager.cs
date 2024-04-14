using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager ScoreInstance;
    [SerializeField] TextMeshProUGUI textMeshPro;


    int _score = 0;
    private void Awake()
    {
        ScoreInstance = this;
    }
    private void Start()
    {
        textMeshPro.text = _score.ToString();
    }
    private void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {

        textMeshPro.text = _score.ToString();
    }

    public int GetScore()
    {
        return _score;
    }
    public int UpdateScore(int point)
    {
        _score += point;
        return _score;
    }

}