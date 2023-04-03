using System;
using System.Collections.Generic;

namespace Pool
{
    public abstract class PoolBase<TData, TType> where TData: IPoolObject where TType: Enum
    {
        protected readonly Queue<TData> UsedObjects = new Queue<TData>();
        protected readonly Queue<TData> UnusedObjects = new Queue<TData>();

        public abstract TData GetOrCreateObject(TType typeObj);
        
        public void HideAllObjects()
        {
            while (UsedObjects.Count > 0)
            {
                var selectedObject = UsedObjects.Dequeue();
                selectedObject.Hide();
                UnusedObjects.Enqueue(selectedObject);
            }

            UsedObjects.Clear();
        }

        public void DestroyAllObjects()
        {
            while (UsedObjects.Count > 0)
            {
                var selectedObject = UsedObjects.Dequeue();
                selectedObject.Destroy();
            }

            while (UnusedObjects.Count > 0)
            {
                var selectedObject = UnusedObjects.Dequeue();
                selectedObject.Destroy();
            }

            UsedObjects.Clear();
            UnusedObjects.Clear();
        }
    }
}