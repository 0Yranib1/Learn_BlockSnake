using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Snake : MonoBehaviour
{
    public PlayerControls playerControls;
    public List<Transform> body;
    public Transform bodyPartPrefab;
    public Transform tailPartPrefab;
    // Start is called before the first frame update
    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Keyboard.Up.started += turnUp;
        playerControls.Keyboard.Down.started += turnDown;
        playerControls.Keyboard.Left.started += turnLeft;
        playerControls.Keyboard.Right.started += turnRight;
        playerControls.Keyboard.PauseGame.started += Pause;
        // playerControls.Keyboard.RestarGame.started += Restar;
    }
    void Start()
    {
        body = new List<Transform>();
        body.Add(transform);
    }
    void OnEnable()
    {
        playerControls.Enable();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Grow();
        }else if (other.CompareTag("Wall") || other.CompareTag("Player"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        GameManager.Instance.GameOver();
        for (int i = 1; i < body.Count; i++)
        {
            Destroy(body[i].gameObject);
        }
        body.Clear();
        body.Add(transform);
        this.transform.position = new Vector3(0, 1, 0);
    }
    void Grow()
    {
        if (body.Count < 2)
        {
            Transform tail = Instantiate(tailPartPrefab, body[body.Count-1].position-body[body.Count-1].forward, body[body.Count-1].rotation);
            body.Add(tail);
        }else
        {
            Transform bodyPart = Instantiate(bodyPartPrefab, body[body.Count-2].position-body[body.Count-2].forward, body[body.Count-2].rotation);
            body[body.Count-1].position = body[body.Count-2].position-body[body.Count-2].forward*2;
            body.Insert(body.Count-1, bodyPart);
        }
    }

    private void FixedUpdate()
    {
        for (int i = body.Count-1; i >0; i--)
        {
            body[i].position = body[i-1].position;
            body[i].rotation = body[i-1].rotation;
        }
        
        transform.position = new Vector3(Mathf.Round(transform.position.x)+transform.forward.x , 
            Mathf.Round(transform.position.y) +0f,
            Mathf.Round(transform.position.z) + transform.forward.z);
    }

    #region 键盘控制

    private void turnUp(InputAction.CallbackContext context)
    {
        if (transform.forward != new Vector3(0, 0, 1))
        {
            transform.forward = new Vector3(0,0,-1);
        }
    }
    private void turnDown(InputAction.CallbackContext context)
    {
        if (transform.forward != new Vector3(0, 0, -1))
        {
            transform.forward = new Vector3(0, 0, 1);
        }
    }
    private void turnLeft(InputAction.CallbackContext context)
    {
        if (transform.forward != new Vector3(-1, 0, 0))
        {
            transform.forward = new Vector3(1, 0, 0);
        }
    }
    private void turnRight(InputAction.CallbackContext context)
    {
        if(transform.forward != new Vector3(1, 0, 0)
               )
            transform.forward = new Vector3(-1, 0, 0);
    }

    private void Pause(InputAction.CallbackContext context)
    {
            UIManager.Instance.PauseGame();
    }
    #endregion
}
