using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace com.jesusnoseq.util
{
    public class Leaderboard : MonoBehaviour
    {
        [SerializeField]
        private GameObject content;

        [SerializeField]
        private GameObject entryPrefab;

        public void AddNewEntry(int position, string name, string score){
            GameObject entryGO = Instantiate(entryPrefab, content.transform);
            Entry entry=entryGO.GetComponent<Entry>();
            entry.SetValues(position, name, score);
        }

        public void CleanAllEntries(){
            Transform tr =content.transform;
            int childs = tr.childCount;
            for (int i = childs - 1; i > 0; i--)
            {
                GameObject.Destroy(tr.GetChild(i).gameObject);
            }
        }
    }
}
