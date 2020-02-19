using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] Rigidbody2D rigidbody;
    public string accelerate = "Accelerate";
    private Vector2 direction;
    private Vector3 clickPose;
    private float currentSpeed;
    private void Start()
    {
        

    }
    private void FixedUpdate()
    {
       // currentSpeed = rigidbody.velocity.magnitude;
       
        Debug.Log(currentSpeed);
        Rotation();
        Moveing();
    }

    private void Update()
    {
    }
    private void Rotation()
    {

        // Определяем угол поворота в радианах при помощи тангенса координат направления; переводим радианы в градусы
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        // Задаем переменную вращения на угол angle по оси Z(Vector3.back)
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);

        // Применяем вращение к игроку, экстраполируя текущие координаты вращения (transform.rotation) 
        // и вычисленные ранее (rotation) во времени (speed*time.deltatime)
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
    private void Moveing()
    {
        if (Input.GetButton(accelerate))
        {
            clickPose = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = clickPose - transform.position;
            rigidbody.AddForce(transform.up * moveSpeed);
        }
    }
}
