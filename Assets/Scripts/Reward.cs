using UnityEngine;

public enum RewardColor
{
        Red, Blue, Green, Black
}

public class Reward : MonoBehaviour
{
    [Header("Reward Settings")]
    [SerializeField] private RewardColor rewardColor;  // Unity 에디터에서 설정할 수 있는 색상
    
    // 여기부터 색깔별 점수의 초기 설정값
    [SerializeField] private int redScore = 10;
    [SerializeField] private int blueScore = 20;
    [SerializeField] private int greenScore = 30;    
    [SerializeField] private int blackScore = 40;

    public int rewardScore { get; private set; }  // 리워드의 점수 (외부에서 읽기 가능)

    // 실시간으로 reward 개체의 색깔을 인스펙터에서 변경하게 하는 코드
    private void OnValidate()
    {
        ApplyColorAndScore();
    }
    private void Start()
    {
        ApplyColorAndScore();
    }

    // 색상과 점수를 설정하는 메서드
    private void ApplyColorAndScore()
    {
        Color color = Color.white;
        switch (rewardColor)
        {
            case RewardColor.Red:
                color = Color.red;
                rewardScore = redScore;
                break;
            case RewardColor.Blue:
                color = Color.blue;
                rewardScore = blueScore;
                break;
            case RewardColor.Green:
                color = Color.green;
                rewardScore = greenScore;
                break;
            case RewardColor.Black:
                color = Color.black;
                rewardScore = blackScore;
                break;
            default:
                rewardScore = 0;  // 기본 점수 설정
                break;
        }

        // 선택한 색상을 적용
        GetComponent<MeshRenderer>().material.color = color;
    }
}
