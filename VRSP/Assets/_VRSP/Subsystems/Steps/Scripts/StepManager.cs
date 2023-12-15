using UnityEngine;

namespace WiseMonkeES.Util.Stepbase
{
    public class StepManager: MonoBehaviour
    {
        public static StepManager Instance { get; private set; }
        public int CurrentStepIndex { get; private set; }
        public int TotalSteps { get; private set; }
        private Stepbase [] Steps => GetComponentsInChildren<Stepbase>();
        
        [SerializeField] private bool _debugMode;
        [SerializeField] private KeyCode _nextStepKey = KeyCode.K;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                CurrentStepIndex = 0;
                TotalSteps = transform.childCount;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        private void Start()
        {
            OrderSteps();
            // initialize steps
            foreach (var step in Steps)
            {
                step.Initialize();
            }
            Steps[CurrentStepIndex].StartStep();
            Steps[CurrentStepIndex].name = CurrentStepIndex + "-Step <--";
        }
        
        private void Update()
        {
            if (_debugMode)
            {
                if (Input.GetKeyDown(_nextStepKey))
                {
                    Steps[CurrentStepIndex].CompleteStep();
                }
            }
        }
        
        public void NextStep()
        {
            if (CurrentStepIndex < TotalSteps)
            {
                Steps[CurrentStepIndex].name = CurrentStepIndex + "-Step";
                CurrentStepIndex++;
                Steps[CurrentStepIndex].StartStep();
                Steps[CurrentStepIndex].name = CurrentStepIndex + "-Step <--";
            }
        }
        
        [ContextMenu("Order Steps")]
        
        private void OrderSteps()
        {
            for (int i = 0; i < Steps.Length; i++)
            {
                Steps[i].StepIndex = i;
                // rename steps
                Steps[i].name = i + "-Step";

            }
        }
    }
}