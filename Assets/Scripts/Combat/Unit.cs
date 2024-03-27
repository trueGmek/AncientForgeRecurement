using UnityEngine;


namespace AFSInterview.Combat
{
    public class Unit : MonoBehaviour
    {
        public string name;

        public virtual void Tick()
        {
            Debug.Log($"Tick from {name}");
        }
    }
}