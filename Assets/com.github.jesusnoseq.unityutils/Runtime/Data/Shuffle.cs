using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.jesusnoseq.util
{
    // How to use it
    //  shuffler = new Shuffle();
    //  shuffler.Execute<Items>(allItems);
    public class Shuffle 
    {
        private System.Random rnd = new System.Random();

        public void Execute<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        internal void Execute<T>(ArrayList paths)
        {
            throw new NotImplementedException();
        }
    }
}