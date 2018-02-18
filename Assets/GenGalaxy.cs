using UnityEngine;
using System.Collections;

public class GenGalaxy : MonoBehaviour {
	public GameObject ellipse;
	public GameObject clouds;
	public GameObject nebula;
	public GameObject h11Regions;
	GameObject center;
	public int numEllipse = 120;
	public int numClouds = 120;
	public int numH11 = 120;
	
	public int numNebula = 1;
	public float scaleDelta = .1f;
	public float angleDelta = 3f;
	// Use this for initialization
	void Awake () {
		
		GameObject g;
        center = gameObject;

		

		//dhould be evenly distributed in a circle
		for(int i =1; i<= numNebula; i++){
			g = Instantiate(nebula,center.transform.position,Quaternion.identity) as GameObject;
			g.transform.SetParent (center.transform);
			g.transform.GetChild (0).gameObject.transform.localScale += 
					new Vector3 (1+numEllipse*scaleDelta,1+numEllipse*scaleDelta,1+numEllipse*scaleDelta);
			//g.transform.GetChild (0).gameObject.transform.localPosition -= new Vector3 (0,(1+numEllipse*scaleDelta)/2f,0);
			//g.transform.GetChild (0).gameObject.GetComponent<ParticleSystem> ().startSize = .1f/(scaleDelta*i+1);
			//Vector3 t = g.transform.eulerAngles + (i * angleDelta) * new Vector3 (0, 0, 1);
			//g.transform.eulerAngles = Vector3.Lerp (g.transform.eulerAngles, t, 1f);
		}
		for (int i = numClouds/2; i <= numClouds; i++) {

			g = Instantiate(clouds,center.transform.position,Quaternion.identity) as GameObject;
			g.transform.SetParent (center.transform);
			g.transform.GetChild (0).gameObject.transform.localScale += new Vector3 (1+i*scaleDelta,1+i*scaleDelta,1+i*scaleDelta);
			g.transform.GetChild (0).gameObject.transform.localPosition -= new Vector3 (0,(1+i*scaleDelta)/2f,0);
            g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startSize = (g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startSize / ((i * (scaleDelta))));
            ParticleSystem.MainModule m = g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().main;
            m.simulationSpeed = m.simulationSpeed / (i * (scaleDelta));
            Vector3 t = g.transform.eulerAngles + (i * angleDelta) * new Vector3 (0, 0, 1);
			g.transform.eulerAngles = Vector3.Lerp (g.transform.eulerAngles, t, 1f);
		}
		for (int i = 1; i <= numEllipse; i++) {

			g = Instantiate(ellipse,center.transform.position,Quaternion.identity) as GameObject;
			g.transform.SetParent (center.transform);
            g.transform.GetChild (0).gameObject.transform.localScale += new Vector3 (1+i*scaleDelta,1+i*scaleDelta,1+i*scaleDelta);
            g.transform.GetChild (0).gameObject.transform.localPosition -= new Vector3 (0,(1+i*scaleDelta)/2f,0);
            //g.transform.GetChild (0).gameObject.GetComponent<ParticleSystem> ().startSize = ((-.05f / numEllipse) * i + .2f);//.1f/(scaleDelta*i+1);
            //g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startSize = g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startSize/ ((i * (scaleDelta)));
            g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startSize = (g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startSize / ((i * (scaleDelta)))) + ((-.05f / numEllipse) * i + .2f);
            ParticleSystem.MainModule m= g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().main;
            m.simulationSpeed = m.simulationSpeed/ (i * (scaleDelta));
            Vector3 t = g.transform.eulerAngles + (i * angleDelta) * new Vector3 (0, 0, 1);
			g.transform.eulerAngles = Vector3.Lerp (g.transform.eulerAngles, t, 1f);
		}

		for (int i = numEllipse/4; i <= numH11; i++) {

			g = Instantiate(h11Regions,center.transform.position,Quaternion.identity) as GameObject;
			g.transform.SetParent (center.transform);
			g.transform.GetChild (0).gameObject.transform.localScale += new Vector3 (1+i*scaleDelta,1+i*scaleDelta,1+i*scaleDelta);
			g.transform.GetChild (0).gameObject.transform.localPosition -= new Vector3 (0,(1+i*scaleDelta)/2f,0);
			g.transform.GetChild (0).gameObject.GetComponent<ParticleSystem> ().startSize = ((-.1f / numH11) * i + .1f);
			g.transform.GetChild (0).gameObject.GetComponent<ParticleSystem> ().startDelay = Random.Range (1, 10) / 10f;
			Vector3 t = g.transform.eulerAngles + (i * angleDelta) * new Vector3 (0, 0, 1);
            ParticleSystem.MainModule m = g.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().main;
            m.simulationSpeed = m.simulationSpeed / (i * (scaleDelta));
            g.transform.eulerAngles = Vector3.Lerp (g.transform.eulerAngles, t, 1f);
			i+=5;
		}

	}
	

}
