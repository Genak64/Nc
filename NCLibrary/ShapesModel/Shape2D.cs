using System;
using System.Collections;
using System.Collections.Generic;

namespace NcLibrary
{
    public class Shape2D : IEnumerator<Path2D>
    {
        public List<Path2D> shape { get; set; }
        int currentIndex { get; set; }
        Path2D IEnumerator<Path2D>.Current { get { return shape[currentIndex]; } }
        object IEnumerator.Current { get { return shape[currentIndex]; } }


        public Shape2D()
        {
            shape = new List<Path2D>();
            currentIndex = -1;
        }

        public void AddPath (Path2D path)
        {
            shape.Add(path);
        }

        public Path2D GetPath(int index)
        {
            if (shape.Count>index) return shape[index];
            else return shape[shape.Count-1];
        }

        public int GetPathCount()
        {
            return shape.Count;
        }

        public IEnumerator<Path2D> GetEnumerator()
        {
            return shape.GetEnumerator();
        }

        bool IEnumerator.MoveNext()
        {
            if (shape.Count >= currentIndex)
            {
                currentIndex++;
                return true;
            }
            else
            {
                return false;
            }
        }

        void IEnumerator.Reset()
        {
            currentIndex = -1;
        }

        void IDisposable.Dispose() { }
       
        
        
    }
}
