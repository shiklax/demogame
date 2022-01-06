using System.Collections;
using UnityEngine;

public class CheckPointTextScript : MonoBehaviour {
    [SerializeField] float tweenTime;
    [SerializeField] float tweenDelay;
    [SerializeField] float waitTillDelete;
    [SerializeField] float deleteTime;
    [SerializeField] LeanTweenType TweenType;
    private void OnEnable() {
        StartCoroutine("TweenLetters");
    }
    IEnumerator TweenLetters() {
        int counter = 0;
        foreach (Transform child in transform) {
            child.gameObject.SetActive(true);
            LeanTween.move(child.gameObject, new Vector3(child.transform.position.x, child.transform.position.y + 0.2f, child.transform.position.z), tweenTime).setEase(TweenType);
            counter++;
            yield return new WaitForSeconds(tweenDelay);
        }
        if (counter == 10) {
            foreach (Transform child in transform) {
                LeanTween.move(child.gameObject, new Vector3(child.transform.position.x, child.transform.position.y - 0.2f, child.transform.position.z), tweenTime).setEase(TweenType);
                counter++;
                yield return new WaitForSeconds(tweenDelay);
            }
        }
        yield return new WaitForSeconds(waitTillDelete);
        if (counter == 20) {
            foreach (Transform child in transform) {
                yield return new WaitForSeconds(deleteTime);
                child.gameObject.SetActive(false);
            }
            this.gameObject.SetActive(false);
        }
    }
}
