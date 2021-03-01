
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] GameObject[] objects;
    [SerializeField] float minX, maxX;
    [SerializeField] BoxCollider bC;
    int score;
    public int GetScore => score;
    private void Start()
    {
        ResetScore();
        for (int i = 0; i < objects.Length; i++)
        {
            RelocatePosition(objects[i]);
            objects[i].GetComponent<Missile>().Init(RelocatePosition);
        }
    }
  public  void ResetScore() => score = 0;
    void RelocatePosition(GameObject go)
        => go.transform.position = GetRandomVector();
    

    Vector3 GetRandomVector()
        => new Vector3(Random.Range(minX,maxX), 1, 22);

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Missile>().ActivateEvent();
        score++;
        UiHandler._Instance.Score(score);
    }
}
