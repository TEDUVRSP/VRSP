using UnityEngine.XR.Interaction.Toolkit;

public class WMGrabbable : XRGrabInteractable
{
    private int _defLayer;
    
    private void Start()
    {
        _defLayer = gameObject.layer;
    }
    
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // set layer to interactors layer
        gameObject.layer = args.interactorObject.transform.gameObject.layer;
        base.OnSelectEntered(args);

    }
    
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        // set layer to default layer
        CoroutineSingleton.Instance.ExecuteAfterDelay(.5f, () => {gameObject.layer = _defLayer;});
        base.OnSelectExited(args);
    }
    
}
