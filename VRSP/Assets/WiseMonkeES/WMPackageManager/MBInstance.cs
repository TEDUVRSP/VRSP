using UnityEngine;

namespace WiseMonkeES.Util
{
    public class MBInstance: MonoBehaviour
    {
        // Don't destroy this object when loading a new scene

        private static MBInstance instance;
        public static MBInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameObject("MBInstance").AddComponent<MBInstance>();
                    
                }
                return instance;
            }
        }

    }
}