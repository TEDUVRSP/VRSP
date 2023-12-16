using System;
using System.Collections.Generic;
using _VRSP.Subsystems.Programming;
using UnityEngine;

public class ProgramManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<ProgramFragment> _allFragments;
    [SerializeField] private List<ProgramFragment> _targetProgram;
    private ProgramFragment _currentFragment;
    public static ProgramManager Current;
    
    #endregion

    #region Unity Event Functions

    public void Awake()
    {
        Current = this;
    }

    #endregion

    #region Public functions

    public void BeginLinking(ProgramFragment fragment)
    {
        _currentFragment = fragment;
        Debug.Log("begin fragment", fragment.gameObject);
    }

    public void EndLinking(ProgramFragment fragment)
    {
        Debug.Log("end fragment", fragment.gameObject);

        if (fragment == null || fragment == _currentFragment)
            return;
        
        _currentFragment.Link(fragment);

        _currentFragment = null;
    }

    private bool CheckProgram()
    {
        for (var index = 0; index < _targetProgram.Count-1; index++)
        {
            if (_targetProgram[index].linkedFragment != _targetProgram[index + 1])
                return false;
        }

        return true;
    }

    #endregion
}
