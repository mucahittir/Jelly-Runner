using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAgent : MonoBehaviour
{
    [SerializeField] float speed, forwardSpeed;
    [SerializeField] GameObject oneBigObj, manySmallObj;
    [SerializeField] int startingCount;
    [SerializeField]BigJelly bigJelly;

    Vector3 moveDir;
    PlayerMode currentMode;
    List<SmallJelly> smallJellies;

    public void Initialize()
    {
        Debug.Log("aa");
        smallJellies = new List<SmallJelly>();

        for(int i = 0; i < startingCount; i++)
        {
            SmallJelly smallJelly = PoolManager.Instance.GetItem("SmallJelly") as SmallJelly;
            smallJelly.SetActiveWithPosition(transform.position);
            smallJelly.transform.SetParent(manySmallObj.transform);
            smallJellies.Add(smallJelly);
        }

        setBigMode();
    }
    public void StartGame()
    {

    }

    public void Reload()
    {

    }

    public void GameOver()
    {

    }
    public void GameSuccess()
    {

    }
    public void Movement(float inputX)
    {
        moveDir.x = inputX * speed * Time.deltaTime;
        moveDir.y = 0;
        moveDir.z = forwardSpeed * Time.deltaTime;

        transform.position += moveDir;
    }
    public void ChangeMode()
    {
        switch (currentMode)
        {
            case PlayerMode.OneBig:
                setSmallMode();
                break;
            case PlayerMode.ManySmall:
                setBigMode();
                break;
            default:
                break;
        }
    }

    private void setSmallMode()
    {
        bigJelly.transform.DOScale(new Vector3(1, 1, 1), 0.2f).OnComplete(() => oneBigObj.SetActive(false));
        manySmallObj.SetActive(true);
        currentMode = PlayerMode.ManySmall;

        foreach (SmallJelly item in smallJellies)
        {
            item.transform.localPosition = Vector3.zero;
            item.transform.DOLocalMove(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)), 0.2f);
        }
    }

    private void setBigMode()
    {
        oneBigObj.SetActive(true);
        manySmallObj.SetActive(false);
        currentMode = PlayerMode.OneBig;

        float sizeCoef = (smallJellies.Count * 0.5f) + 1f;
        bigJelly.transform.DOScale(new Vector3(sizeCoef, sizeCoef, sizeCoef), 0.2f);

        foreach (SmallJelly item in smallJellies)
        {
            item.transform.DOLocalMove(Vector3.zero, 0.2f);
        }


    }
}

public enum PlayerMode : int
{
    OneBig,
    ManySmall
}