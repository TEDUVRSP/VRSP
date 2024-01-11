using UnityEngine;
using UnityEngine.Events;

namespace WiseMonkeES.Util.Stepbase
{
    public abstract class Stepbase : MonoBehaviour
    {
        [SerializeField] protected UnityEvent OnStepStart;
        [SerializeField] protected UnityEvent OnStepComplete;
        public string description;
        public int StepIndex { get; set; }
        [SerializeField] protected bool _isComplete;
        
        
        public virtual void StartStep()
        {
            OnStepStart.Invoke();
            _isComplete = false;
        }
        
        public virtual void CompleteStep()
        {
            if(_isComplete) return;
            OnStepComplete.Invoke();
            _isComplete = true;
            StepManager.Instance.NextStep();
        }
        
        public virtual void BindOnStepStart(UnityAction action)
        {
            OnStepStart.AddListener(action);
        }
        
        public virtual void BindOnStepComplete(UnityAction action)
        {
            OnStepComplete.AddListener(action);
        }
        
        public virtual void UnbindOnStepStart(UnityAction action)
        {
            OnStepStart.RemoveListener(action);
        }
        
        public virtual void UnbindOnStepComplete(UnityAction action)
        {
            OnStepComplete.RemoveListener(action);
        }
        
        
        // common function initialize step on start
        public abstract void Initialize();


    }

    
}