// Script by Marcelli Michele

using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PadLockPassword : MonoBehaviour
{
    MoveRuller _moveRull;
    Animator _animator;
    public Animation _animation;

    public int[] _numberPassword = {0,0,0,0};

    private void Awake()
    {
        _moveRull = FindObjectOfType<MoveRuller>();
        _animator = GetComponent<Animator>();

    }

    public void Password()
    {
            _animator.enabled = true;
            // Es. Below the for loop to disable Blinking Material after the correct password
            for (int i = 0; i < _moveRull._rullers.Count; i++)
            {
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>()._isSelect = false;
                _moveRull._rullers[i].GetComponent<PadLockEmissionColor>().BlinkingMaterial();
            }
        if (_animation != null)
        {
            _animation.Play();
            Interactable _interactable = _animation.GetComponentInParent<Interactable>();
            _interactable.SetEvent(1);
        }
           
        
    }
    public bool CheckPassword()
    {
        if (_moveRull._numberArray.SequenceEqual(_numberPassword))
            return true;
        return false;
    }
}
