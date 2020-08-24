using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    float xInitialForce = 50;
    float yInitialForce = 15;
    private PlayerControl player1;
    private PlayerControl player2;
    private BallControl ball;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<PlayerControl>();
        player2 = GameObject.Find("Player2").GetComponent<PlayerControl>();
        ball = GameObject.Find("Ball").GetComponent<BallControl>();
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        PushBall();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player1")
        {
            player2.IncrementScore();
            ball.RestartGame();
            FireBallSpawner.isSpawned = false;
            Destroy(gameObject);
        }
        else if(collision.gameObject.name=="Player2")
        {
            player1.IncrementScore();
            ball.RestartGame();
            FireBallSpawner.isSpawned = false;
            Destroy(gameObject);
        }
    }

    void PushBall()
    {
        float yRandomInitialForce = Random.Range(0, 2);
        if (yRandomInitialForce < 1)
        {
            yRandomInitialForce = -yInitialForce;
        }

        else
        {
            yRandomInitialForce = yInitialForce;
        }

        float randomDirection = Random.Range(0, 2);
        if (randomDirection < 1.0f)
        {
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }
}
