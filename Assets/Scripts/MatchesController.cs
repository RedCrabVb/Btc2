using UnityEngine;
using UnityEngine.UI;
public class MatchesController : MonoBehaviour
{
    public Text countText;
    private int count = 4;
    public GameObject matchstickModel;

    private void Start()
    {
        countText.text = count.ToString();
    }

    public void Ignite()
    {
        matchstickModel.SetActive(false);
        if (count > 0)
        {
            matchstickModel.SetActive(true);
            matchstickModel.GetComponent<Animator>().enabled = true;
            UpdateCount(-1);
        }
    }

    public void Add()
    {
        UpdateCount(Random.Range(1, 3));
    }

    private void UpdateCount(int i)
    {
        count += i;
        countText.text = count.ToString();
    }
}
