using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DetectObject : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI tmp;

    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(score==6)
        {
            tmp.text = "You Win";
            StartCoroutine("Wait");

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        score = 0;
        tmp.text = " ";
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
      
    }
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if(collision.gameObject.name[0] == this.gameObject.name[0])
        {

            collision.gameObject.SetActive(false);
            score += 1;
            tmp.text = score.ToString();
        }
        else
        {
            Debug.Log("Wrong Box");
            tmp.text = "Wrong Box";
        }
    }
}
