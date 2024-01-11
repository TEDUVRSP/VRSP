using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using WiseMonkeES.Util.Stepbase;

public class CorrectProgramStep : Stepbase
{
    #region Variables

    [SerializeField] private ProgramManager _program;
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _successfulScreen;

    #endregion

    #region Private Functions

    private void CheckProgram()
    {
        if (_program.CheckProgram())
        {
            CompleteStep();
        }
        else
        {
            _program.ResetConnections();
        }
    }

    #endregion

    public override void StartStep()
    {
        base.StartStep();
    }

    public override void CompleteStep()
    {
        base.CompleteStep();
    }

    public override void BindOnStepStart(UnityAction action)
    {
        base.BindOnStepStart(action);
    }

    public override void BindOnStepComplete(UnityAction action)
    {
        base.BindOnStepComplete(action);
        _successfulScreen.SetActive(true);
    }

    public override void UnbindOnStepStart(UnityAction action)
    {
        base.UnbindOnStepStart(action);
    }

    public override void UnbindOnStepComplete(UnityAction action)
    {
        base.UnbindOnStepComplete(action);
    }

    public override void Initialize()
    {
        _button.onClick.AddListener(CheckProgram);
        _successfulScreen.SetActive(false);
    }
}