using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Ball _ballsPrefab;
    [SerializeField] private List<Ball> _balls = new List<Ball>();


    private void Start()
    {
        _balls.Add(GetComponentInChildren<Ball>());
    }

    private void ArrangeBalls(float radius = 1.5f)
    {
        int count = _balls.Count;
        for (int i = 0; i < count; i++)
        {
            float radians = 2 * Mathf.PI / count * i;
            float vertical = Mathf.Sin(radians);
            float horizontal = Mathf.Cos(radians);

            Vector3 spawnDir = new Vector3(horizontal, 0, vertical);
            Vector3 spawnPos = spawnDir * radius;

            _balls[i].transform.localPosition = spawnPos;

            var pos = _balls[i].transform.position;
            pos.x = Mathf.Clamp(pos.x, -9f, 9f);
            _balls[i].transform.position = pos;
        }
    }

    public void Addition(int value)
    {
        if (value > 0)
        {
            for (int i = 0; i < value; i++)
            {
                Ball newBall = Instantiate(_ballsPrefab, transform);
                _balls.Add(newBall);
            }
            ArrangeBalls();
        }
        else
        {
            int number =Mathf.Abs(value);
            Debug.Log(number);
            for (int i = 0; i < number; i++)
            {
                _balls.Remove(_balls[i]);
            }
            _balls.RemoveAll(x => x == null);
            ArrangeBalls();
        }
    }


    public void Multiple()
    {
        int balls = _balls.Count;
        for (int i = 0; i < balls; i++)
        {
            Ball newBall = Instantiate(_ballsPrefab, transform);
            _balls.Add(newBall);
        }
        ArrangeBalls();
    }
}

