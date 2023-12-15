namespace WiseMonkeES.Util.Stepbase.Steps
{
    public class SampleStep: Stepbase
    {
        
        public void Control()
        {
        }

        public override void CompleteStep()
        {
            
            print("Step " + StepIndex + "Completed");
            
            base.CompleteStep();
        }
        
        public override void StartStep()
        {
            
            print("Step " + StepIndex + "Started");
            
            base.StartStep();
        }

        public override void Initialize()
        {
            print("Step " + StepIndex + "Initialized");
        }
    }
}