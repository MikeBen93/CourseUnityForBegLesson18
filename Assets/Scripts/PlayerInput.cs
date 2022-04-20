using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Shooting))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private Shooting _shooting;
    private Animator _playerAnimator;

    private float _horizontalDirection = 0f;
    private bool _isJumpButtonPressed = false;

    public float HorizontalDirection
    {
        get
        {
            return _horizontalDirection;
        }
    }

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<Shooting>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontalDirection = Input.GetAxis(GlobalStringVars.HorizontalAxis);
        _isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.Jump);

        if(Input.GetButtonDown(GlobalStringVars.Fire1))
        {
            _playerAnimator.SetTrigger("Shooting");
        }

        if (Input.GetButtonDown(GlobalStringVars.Fire2))
        {
            _playerAnimator.SetTrigger("Attacking");
        }

        _playerMovement.Move(_horizontalDirection, _isJumpButtonPressed);
    }



}
