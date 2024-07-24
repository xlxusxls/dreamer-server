using UnityEngine;

public class PlayerFitness : MonoBehaviour
{
    // 초기값이 0인 float 자료형 fitness 멤버변수 생성
    public float fitness = 0.0f;
    public float addRate = 0.0001f;

    // Update 멤버함수에서 매 프레임마다 addRate 더해줌
    void Update()
    {
        fitness += addRate;
    }
}
