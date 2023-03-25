using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject Simili;
    public GameObject Player;
    [SerializeField] LayerMask ObstacleLayer;
    public Transform PlayerStartingPoint;
    public Transform SimiliStartingPoint;

    private CapsuleCollider2D SimiliCollider;
    private CapsuleCollider2D PlayerCollider;

    private void Start()
    {
        this.SimiliCollider = Simili.GetComponent<CapsuleCollider2D>();
        this.PlayerCollider = Player.GetComponent<CapsuleCollider2D>();
        this.Player.transform.position = this.PlayerStartingPoint.position;
        this.Simili.transform.position = this.SimiliStartingPoint.position;
    }

    void Update()
    {
        if (Physics2D.IsTouchingLayers(SimiliCollider, ObstacleLayer))
        {
            this.Player.transform.position = this.PlayerStartingPoint.position;
            this.Simili.transform.position = this.SimiliStartingPoint.position;
        }
        else if (Physics2D.IsTouchingLayers(PlayerCollider, ObstacleLayer))
        {
            this.Player.transform.position = this.PlayerStartingPoint.position;
            this.Simili.transform.position = this.SimiliStartingPoint.position;
        }
    }
}
