using UnityEngine;
using System.Collections;

namespace com.jesusnoseq.util
{
	public class DontDestroy : MonoBehaviour {
	    void Start()
	    {
		    DontDestroyOnLoad(this.gameObject);
	    }
    }

}