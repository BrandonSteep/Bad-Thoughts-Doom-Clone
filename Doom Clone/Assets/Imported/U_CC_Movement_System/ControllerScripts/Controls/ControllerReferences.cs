using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerReferences : MonoBehaviour
{
    public static ControllerReferences instance { get; private set; }

    // Player //
    public static GameObject player;
    public static CharacterController characterController;
    public static PlayerController playerController;
    public static PlayerStatus playerStatus;
    public static Camera cam;
    public static PlayerKnockback playerKnockback;
    public static Animator playerAnim;

    public static BoomerShooterWeaponSystem equipmentManager;
    public static AbilityHolder abilityHolder;



    void Awake()
    {
        instance = this;
        
        player = this.gameObject;
        characterController = player.GetComponent<CharacterController>();
        playerController = player.GetComponent<PlayerController>();
        playerStatus = player.GetComponent<PlayerStatus>();
        cam = Camera.main;
        playerKnockback = player.GetComponent<PlayerKnockback>();
        playerAnim = player.GetComponent<Animator>();
        equipmentManager = GameObject.FindWithTag("Equipped").GetComponent<BoomerShooterWeaponSystem>();
        abilityHolder = GameObject.FindWithTag("Ability").GetComponent<AbilityHolder>();
    }



    // PAUSE //

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }



    // RESUME //

    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
