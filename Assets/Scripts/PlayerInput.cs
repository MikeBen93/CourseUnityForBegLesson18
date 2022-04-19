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


    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _shooting = GetComponent<Shooting>();
        _playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        _isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        if(Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            //_shooting.Shoot(_horizontalDirection);
            _playerAnimator.SetTrigger("Shooting");
        }

        if (Input.GetButtonDown(GlobalStringVars.FIRE_2))
        {
            //_shooting.Shoot(_horizontalDirection);
            _playerAnimator.SetTrigger("Attacking");
        }

        _playerMovement.Move(_horizontalDirection, _isJumpButtonPressed);
    }


    public float HorizontalDirection
    {
        get
        {
            return _horizontalDirection;
        }
    }
}
