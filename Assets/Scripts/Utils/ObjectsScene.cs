using UnityEngine;

namespace Utils
{
    public class ObjectsScene : MonoBehaviour
    {
        public static Transform Wall
        {
            get
            {
                if (_wall == null)
                {
                    _wall = GameObject.Find("Wall").transform;
                }

                return _wall;
            }
        }

        private static Transform _wall;
    }
}