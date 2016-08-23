using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BurnCreds : MonoBehaviour {
  [SerializeField]
  public float defaultWaitTime = 1;
  Text cred;
  Text mainTeam;
  Text art;
  Text program;
  Text other;
  Text thanks;
  Text seriously;
  Text specialThanks;
  Text acting;
  Text concept;

	// Use this for initialization
	void Start () {
    cred = GameObject.Find("Credits").GetComponent<Text>();
    mainTeam = GameObject.Find("Main").GetComponent<Text>();
    art = GameObject.Find("Art").GetComponent<Text>();
    program = GameObject.Find("Programming").GetComponent<Text>();
    thanks = GameObject.Find("ThankYou").GetComponent<Text>();
    seriously = GameObject.Find("Seriously").GetComponent<Text>();
    specialThanks = GameObject.Find("SpecialThanks").GetComponent<Text>();
    acting = GameObject.Find("Acting").GetComponent<Text>();
    concept = GameObject.Find("Concept").GetComponent<Text>();
    cred.enabled = false;
    mainTeam.enabled = false;
    art.enabled = false;
    program.enabled = false;
    thanks.enabled = false;
    seriously.enabled = false;
    specialThanks.enabled = false;
    acting.enabled = false;
    concept.enabled = false;
    StartCoroutine(RollCredits());
	}

  void Update() {
    if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
      Application.Quit();
  }
	
    private IEnumerator rollCreditScene(Text textScene, float waitTime)
    {
        textScene.enabled = true;
        textScene.CrossFadeAlpha(0f, 0f, true);
        textScene.CrossFadeAlpha(1f, 0.5f, true);
        yield return new WaitForSeconds(waitTime);
        textScene.CrossFadeAlpha(0f, 0.5f, true);
        yield return new WaitForSeconds(waitTime / 2);
        textScene.enabled = false;
    }

   IEnumerator RollCredits(){
        yield return rollCreditScene(cred, defaultWaitTime);
        yield return rollCreditScene(mainTeam, defaultWaitTime);
        yield return rollCreditScene(concept, 2f);
        yield return rollCreditScene(program, 2.5f);
        yield return rollCreditScene(art, 3f);
        yield return rollCreditScene(acting, 3.5f);
        yield return rollCreditScene(specialThanks, 5f);

        thanks.enabled = true;
        yield return new WaitForSeconds(5f);
        thanks.enabled = false;
        seriously.enabled = true;
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
