using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //player1
    public PlayerControl player1; //skrip
    private Rigidbody2D player1Rigidbody;

    //player2
    public PlayerControl player2; //skrip
    private Rigidbody2D player2Rigidbody;

    //bola
    public BallControl ball; //skrip
    private Rigidbody2D ballRigidbody;
    private CircleCollider2D ballCollider;

    //skor maksimal
    public int maxScore;

    // inisiasi rigidbody dan collider  
    private void Start()
    {
        player1Rigidbody = player1.GetComponent<Rigidbody2D>();
        player2Rigidbody = player2.GetComponent<Rigidbody2D>();
        ballRigidbody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }

    //Untuk menampilkan GUI
    private void OnGUI()
    {
        //menampilkan score player 1 di kiri atas dan player 2 di kanan atas
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12, 20, 100, 100), "" + player1.Score);
        GUI.Label(new Rect(Screen.width / 2 + 150 + 12, 20, 100, 100), "" + player2.Score);

        //tombol restart untuk memulai game dari awal
        if(GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 53),"RESTART"))
        {
            //reset score player 1 dan 2
            player1.ResetScore();
            player2.ResetScore();

            //lalu restart game
            ball.SendMessage("Restart Game", 0.5f, SendMessageOptions.RequireReceiver);
        }

        //jika player1 mencapai sekor maksimal
        if(player1.Score == maxScore)
        {
            // tampilkan teks "player one wins" di kiri layar
            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");
            // bola balik ke tengah
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
        else if (player2.Score == maxScore)
        {
            // tampilkan teks "player two wins" di kanan layar 
            GUI.Label(new Rect(Screen.width / 2 + 30, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");
            // bola balik ke tengah
            ball.SendMessage("ResetBall", null, SendMessageOptions.RequireReceiver);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
