using UnityEngine;


[RequireComponent (typeof(CharacterController), typeof(PlayerMove), typeof(PlayerRotate))]
public class Player : MonoBehaviour
{
    private PlayerMove _move;
    private PlayerRotate _rotate;
    private PlayerRotate _rotateSmooth;
    private PlayerRotate _currentRotate;

    private void Awake()
    {
        _move = GetComponent<PlayerMove>();
        _rotate = GetComponent<PlayerRotate>();
        _rotateSmooth = GetComponent<PlayerRotate>();
        Cursor.lockState = CursorLockMode.Locked;

#if UNITY_EDITOR
        _currentRotate = _rotate;
#else
_currentRotate = _rotate Smooth;
#endif
    }


    private void Update()
    {
        _move.Move();
        _currentRotate.Rotate();
    }

}

