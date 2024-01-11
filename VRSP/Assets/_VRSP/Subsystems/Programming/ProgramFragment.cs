using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _VRSP.Subsystems.Programming
{
    [RequireComponent(typeof(LineRenderer))]
    public class ProgramFragment : MonoBehaviour, IDragHandler,IBeginDragHandler, IDropHandler
    {
        #region Variables

        [SerializeField] private string definition;
        public LineRenderer lineRenderer;
        public ProgramFragment linkedFragment;

        #endregion

        #region Unity Event Functions

        public void Awake()
        {
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.positionCount = 2;
        }
        
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            ProgramManager.Current.BeginLinking(this);
        }

        public void OnDrop(PointerEventData eventData)
        {
            ProgramManager.Current.EndLinking(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            
        }

        #endregion

        #region Public Functions

        public void Link(ProgramFragment target)
        {
            linkedFragment = target;
            lineRenderer.SetPosition(0,transform.position);
            lineRenderer.SetPosition(1,target.transform.position);
        }
        
        public void ResetConnection()
        {
            linkedFragment = null;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
        }
        
        #endregion
    }
}
