using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace com.jesusnoseq.util
{
    [Serializable]
    public class CSVData {
        public string range;
        public string majorDimension;
        public string[] values;

        public override string ToString()
        {
            Debug.Log("Range: "+range);
            Debug.Log("MajorDimension: " + majorDimension);
            //string values = string.Join(values, ".");
            string result = "";

            foreach (string row in values)
            {
                Debug.Log(row);
            }

            /*foreach (string[] row in values)
            {
                foreach (string value in row)
                {
                    Debug.Log(value);
                }
                //result += String.Join("|", row);
            }*/



            return result;
        }
    }
}