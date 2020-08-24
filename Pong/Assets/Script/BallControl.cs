using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    //rigidbody bola
    private Rigidbody2D rigidBody2D;
    //gaya awal untuk mendorong bola
    public float xInitialForce;
    public float yInitialForce;
    //titik asal lintasan bola saat ini
    private Vector2 terajectoryOrigin;

    // Start is called before the first frame update
    void ResetBall()
    {
        //reset posisi jadi (0,0)
        transform.position = Vector2.zero;
        //reset kecepatan jadi (0,0)
        rigidBody2D.velocity = Vector2.zero;
    }

    void PushBall()
    {
        //menentukan nilai gaya dorongan antara -yinitialforce sampai yinitialforce 
        float yRandomInitialForce = Random.Range(0, 2); //Challenge 1
        if (yRandomInitialForce < 1)
        {
            yRandomInitialForce = -yInitialForce;
        }

        else
        {
            yRandomInitialForce = yInitialForce;
        }
                
        //menentukan nilai jarak acak antara 0-2 (ekslusif)
        float randomDirection = Random.Range(0, 2);
        //jika nilai kurang dari 1 bergerak ke kiri
        if (randomDirection < 1.0f)
        {
            //gaya untuk menggerakan bola
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        //jika tidak, bergerak ke kanan
        else
        {
            //gaya untuk menggerakan bola 
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }

    void RestartGame()
    {
        //memanggil fungsi resetball
        ResetBall();
        //memberikan gaya / memanggil fungsi Pushball setelah 2 detik
        Invoke("PushBall", 2);
    }
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        //Mulai game
        RestartGame();
        terajectoryOrigin = transform.position;
    }
    //ketika bola beranjak dari sebuah tumbukan, rekam titik tumbukan tersebut
    private void OnCollisionExit2D(Collision2D collision)
    {
        terajectoryOrigin = transform.position;
    }

    //untuk megakses informasi titik asal lintasan
    public Vector2 TerajectoryOrigin
    {
        get { return terajectoryOrigin; }
    }
}
