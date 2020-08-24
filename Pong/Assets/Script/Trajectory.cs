using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    //script, collider dan rigidbody
    public BallControl ball;
    CircleCollider2D ballCollider;
    Rigidbody2D ballRigidBody;
    // bola "bayangan" yang akan ditampilkan di titik tumbukan
    public GameObject ballAtCollision;

    // inisisasi rigidbody dan circlecollider 
    void Start()
    {
        ballRigidBody = ball.GetComponent<Rigidbody2D>();
        ballCollider = ball.GetComponent<CircleCollider2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        //inisiasi pantulan lintasan, yang hanya ditampilkan ketika lintasan bertmbukan dengan object tertentu
        bool drawBallAtCollision = false;
        //titik tumbukan yang digeser untuk menggambarkan ballAtCollision
        Vector2 offsetHitPoint = new Vector2();

        //tentukan titik tumbuk dengan deteksi pergerakan lingkaran
        RaycastHit2D[] circleCastHit2DArray = Physics2D.CircleCastAll(ballRigidBody.position, ballCollider.radius, ballRigidBody.velocity.normalized);

        //untuk setiap titik tumbukan
        foreach (RaycastHit2D circleCastHit2D in circleCastHit2DArray)
        {
            //jika terjadi tumbukan, dan tumbukan tersebut tidak dengan bola
            //(karena garis lintasan digambar dari titik tengah bola)
            if (circleCastHit2D.collider != null && circleCastHit2D.collider.GetComponent<BallControl>() == null)
            {
                // Tentukan titik tumbukan
                Vector2 hitPoint = circleCastHit2D.point;
                // tentukan normal di titik tumbukan
                Vector2 hitNormal = circleCastHit2D.normal;
                //tentukan offsetHitPoint, yaitu titik tengah bola pada saat bertumbukan
                offsetHitPoint = hitPoint + hitNormal * ballCollider.radius;
                // Gambar garis lintasan dari titik tengah bola saat ini ke titik tengah bola pada saat bertumbukan
                DottedLine.DottedLine.Instance.DrawDottedLine(ball.transform.position, offsetHitPoint);

                if (circleCastHit2D.collider.GetComponent<SideWall>() == null)
                {
                    Vector2 inVector = (offsetHitPoint - ball.TerajectoryOrigin).normalized;
                    Vector2 outVector = Vector2.Reflect(inVector, hitNormal);

                    float outDot = Vector2.Dot(outVector, hitNormal);
                    if (outDot > -1.0f && outDot < 1.0)
                    {
                        DottedLine.DottedLine.Instance.DrawDottedLine(
                            offsetHitPoint,
                            offsetHitPoint + outVector * 10.0f
                            );
                        drawBallAtCollision = true;
                    }
                }
                break;

            }
        }
        if (drawBallAtCollision)
        {
            ballAtCollision.transform.position = offsetHitPoint;
            ballAtCollision.SetActive(true);
        }
        else
        {
            ballAtCollision.SetActive(false);
        }
    }


}
