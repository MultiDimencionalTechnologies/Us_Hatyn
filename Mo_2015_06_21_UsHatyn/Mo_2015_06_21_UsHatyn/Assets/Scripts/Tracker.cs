using UnityEngine;
using System.Collections;

public class Tracker : MonoBehaviour {

	// Use this for initialization
	public Transform target1;

	public bool tracking =false;
	private LineRenderer lineRenderer;
	private NavMeshPath path;

	void Start () {
		path = new NavMeshPath();

		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.SetWidth(5f, 5f);
		//Track (target1);
	}


	public void Track(Transform target){		
		tracking = true;
		NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
		lineRenderer.SetVertexCount (path.corners.Length);
		for (int i = 0; i < path.corners.Length; i++) {
			//Debug.Log(path.corners[i]);
			lineRenderer.SetPosition (i, path.corners [i]);				
		}
	}
	public void StopTracking(){
		tracking = false;
		lineRenderer.SetVertexCount (0);
	}

}