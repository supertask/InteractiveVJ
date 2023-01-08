using UnityEngine;

namespace InteractiveVJ
{

    class CameraController : MonoBehaviour
    {
        [SerializeField] Transform _randomPivot = null;

        public void JumpRandomly()
        {
            _randomPivot.localRotation = RandomRotation;
        }
        public void ReturnToOriginalRoot()
        {
            _randomPivot.localRotation = Quaternion.identity;
        }

        Quaternion RandomRotation
        => Quaternion.Slerp(Quaternion.identity, Random.rotation, 0.5f);

    }
}
