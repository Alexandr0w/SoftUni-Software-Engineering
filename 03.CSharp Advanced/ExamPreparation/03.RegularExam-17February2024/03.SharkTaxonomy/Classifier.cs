﻿using System.Security.Cryptography;
using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public Classifier(int capacity) 
        {
            this.Capacity = capacity;
            this.Species = new List<Shark>();
        }
        public int Capacity { get; }
        public List<Shark> Species { get; }

        public int GetCount => this.Species.Count;

        public void AddShark(Shark shark)
        {
            if (this.Species.Count >= this.Capacity || this.Species.Any(s => s.Kind == shark.Kind)) return;
            
            this.Species.Add(shark);
        }

        public bool RemoveShark(string kind)
        {
            Shark? sharkToRemove = this.Species.SingleOrDefault(s => s.Kind == kind);
            if (sharkToRemove == null) return false;
             
            return this.Species.Remove(sharkToRemove);
        }

        public string GetLargestShark()
        {
            return this.Species.MaxBy(x => x.Length)!.ToString();
        }

        public double GetAverageLength()
        {
            return this.Species.Average(x => x.Length);
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.Append($"{this.GetCount} sharks classifield:");

            foreach (Shark shark in this.Species)
            {
                report.AppendLine($"{shark}");
            }

            return report.ToString().Trim();
        }
    }
}