using Interfaces;
using UnityEngine;

namespace Beginning.CSharp
{
    public class Player : IPersistable
    {
        public string Name;
        public int Score;
        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
     
}
