using System;
using System.Collections.Generic;

namespace Pool
{
    public abstract class PoolBase<TData> where TData: IPoolObject
    {
        protected readonly Queue<TData> UsedObjects = new Queue<TData>();
        protected readonly Queue<TData> UnusedObjects = new Queue<TData>();

        public abstract TData GetOrCreateObject();
        
        public void HideObject(TData obj)
        {
            // Решение с помощью которого можно избавиться от лишней переменной (tempLength)
            if (UsedObjects.Contains(obj) == false)
            {
                return;
            }
            
            while (UsedObjects.Count > 0)
            {
                var selectedObject = UsedObjects.Dequeue();
                if (selectedObject.Equals(obj))
                {
                    selectedObject.Hide();
                    UnusedObjects.Enqueue(selectedObject);
                    break;
                }
            
                UsedObjects.Enqueue(selectedObject);
            }
        }
        
        
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