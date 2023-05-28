using Beginning.CSharp;
using UnityEngine;

namespace LearningObjects
{
    public struct Alien : IShootable
    {
        public Alien(int hitPoints) : this(hitPoints, 100, true){}
        public Alien(int hitPoints, int pointValue, bool isAlive) : this()
        {
            HitPoints = hitPoints;
            PointValue = pointValue;
            Alive = isAlive;
        }
        public int PointValue { get; set; }
        public int HitPoints { get; set; }
        public bool Alive { get; set; }
        public void Fire()
        {
            Debug.Log("The alien got shot.");
            PointValue--;
            Debug.Log("Alien's point value: " + PointValue);
        }

        public void Save()
        {
            PointValue = 100;
            Debug.Log("Alien saved.");
        }
    }
}
