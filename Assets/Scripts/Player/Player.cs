using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public static Player Instance { get; private set; }
    PlayerMovement playerMovement;
    Animator animator;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    
        if (animator == null)
        {
            Debug.LogError("Animator is null! Make sure the 'EngineEffect' GameObject exists and has an Animator component.");
        }
    }
    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        if (animator != null)
        {
            bool isMoving = playerMovement.IsMoving();
            animator.SetBool("IsMoving", isMoving);
            Debug.Log($"IsMoving: {isMoving}"); // Log nilai IsMoving
        }
        else
        {
            Debug.LogError("Animator is null!"); // Log jika animator null        
        }
    }
}

