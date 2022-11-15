using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerAgent : MonoBehaviour
{
    [SerializeField] float speed, forwardSpeed, bigToSmallTime, smallToBigTime;
    [SerializeField] GameObject oneBigObj, manySmallObj ,trailObj ;
    [SerializeField] int startingCount;
    [SerializeField] BigJelly bigJelly;
    [SerializeField] Animator animator;

    bool canChangeMode, isTapped, isGettingSmall;
    Vector3 moveDir;
    PlayerMode currentMode;
    List<SmallJelly> smallJellies;
    IEnumerator bigGetSmaller;

    public void Initialize()
    {
        canChangeMode = false;
        isTapped = false;
        isGettingSmall = false;
        bigJelly.OnDamage = damage;
        bigJelly.OnFinish = finish;
        bigJelly.OnAdd = add;
        fulfillJellies();
        resizeBigJelly();
        toggleTrail(false);
        animator.Play("Idle");
    }
    public void StartGame()
    {
        animator.Play("Running");
        canChangeMode = true;
    }

    public void Reload()
    {
        emptyJellies();
        fulfillJellies();
        resizeBigJelly();
        transform.position = Vector3.zero;
        canChangeMode = false;
        isTapped = false;
        isGettingSmall = false;
        toggleTrail(false);
        bigJelly.gameObject.SetActive(true);
        animator.Play("Idle");
    }

    public void GameOver()
    {
        canChangeMode = false;
        bigJelly.gameObject.SetActive(true);

    }
    public void GameSuccess()
    {
        canChangeMode = false;
        StopCoroutine(bigGetSmaller);
        bigJelly.gameObject.SetActive(true);
    }
    public void Movement(float inputX)
    {
        moveDir.x = inputX * speed * Time.deltaTime;
        moveDir.y = 0;
        moveDir.z = forwardSpeed * Time.deltaTime;

        transform.position += moveDir;
        clampMovement();
    }
    public void ChangeMode()
    {
        if (canChangeMode && !isTapped)
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
    }

    private void emptyJellies()
    {
        for (int i = 0; i < smallJellies.Count; i++)
        {
            smallJellies[i].OnDamage = null;
            smallJellies[i].OnFinish = null;
            smallJellies[i].OnAdd = null;
            smallJellies[i].OnJump = null;
            smallJellies[i].Dismiss();
        }
        smallJellies.Clear();
        smallJellies = null;
    }

    private void fulfillJellies()
    {
        smallJellies = new List<SmallJelly>();

        for (int i = 0; i < startingCount; i++)
        {
            SmallJelly smallJelly = PoolManager.Instance.GetItem("SmallJelly") as SmallJelly;
            smallJelly.SetActiveWithPosition(transform.position);
            smallJelly.transform.SetParent(manySmallObj.transform);
            smallJelly.OnDamage = damage;
            smallJelly.OnFinish = finish;
            smallJelly.OnAdd = add;
            smallJelly.OnJump = jump;
            smallJellies.Add(smallJelly);
        }
    }
    private void clampMovement()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -6.5f, 6.5f);
        transform.position = pos;
    }

    private void resizeBigJelly()
    {
        float sizeCoef = (smallJellies.Count * 0.2f) + 1f;
        bigJelly.transform.DOScale(new Vector3(sizeCoef, sizeCoef, sizeCoef), smallToBigTime);
    }

    private void setSmallMode()
    {
        Vector3 randomValue = Vector3.zero;
        foreach (SmallJelly item in smallJellies)
        {
            randomValue = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            item.transform.localPosition = Vector3.zero;
            item.transform.DOLocalMove(randomValue, bigToSmallTime);
        }
        bigJelly.transform.DOScale(new Vector3(1, 1, 1), bigToSmallTime)
            .OnStart(() =>
            {
                isTapped = true;
            })
            .OnComplete(() => 
            {
                isTapped = false;
                if(canChangeMode)
                    oneBigObj.SetActive(false);

            });
        bigJelly.transform.DOLocalMove(randomValue, bigToSmallTime);
        manySmallObj.SetActive(true);
        currentMode = PlayerMode.ManySmall;
    }

    private void setBigMode()
    {
        oneBigObj.SetActive(true);
        manySmallObj.SetActive(false);
        currentMode = PlayerMode.OneBig;
        resizeBigJelly();

        foreach (SmallJelly item in smallJellies)
        {

            item.transform.DOLocalMove(Vector3.zero, smallToBigTime);
        }

        bigJelly.transform.DOLocalMove(Vector3.zero, smallToBigTime)
            .OnStart(() =>
            {
                isTapped = true;
            })
            .OnComplete(() =>
            {
                isTapped = false;

            });
        animator.Play("Running");
    }

    private void damage()
    {
        SmallJelly jelly = smallJellies[0];
        jelly.OnDamage -= damage;
        smallJellies.Remove(jelly);
        PoolManager.Instance.SetActiveItemWithPosition("Damage",jelly.transform.position);
        jelly.Dismiss();
        resizeBigJelly();

        if(smallJellies.Count <=0)
        {
            GameManager.Instance.GameOver();
        }

    }

    private void finish()
    {
        setBigMode();
        canChangeMode = false;
        toggleTrail(true);
        bigGetSmaller = bigGettingSmaller();
        StartCoroutine(bigGetSmaller);
        isGettingSmall = true;
    }

    private void add(Vector3 collectedPos)
    {
        SmallJelly smallJelly = PoolManager.Instance.GetItem("SmallJelly") as SmallJelly;
        smallJelly.SetActiveWithPosition(collectedPos);
        smallJelly.transform.SetParent(manySmallObj.transform);
        smallJelly.OnDamage = damage;
        smallJelly.OnFinish = finish;
        smallJelly.OnAdd = add;
        smallJelly.OnJump = jump;
        smallJellies.Add(smallJelly);
        if(currentMode == PlayerMode.ManySmall)
        {
            Vector3 randomValue = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            smallJelly.transform.DOLocalMove(randomValue, bigToSmallTime);
        }
        else
        {
            smallJelly.gameObject.SetActive(false);
            resizeBigJelly();
        }

        PoolManager.Instance.SetActiveItemWithPosition("Smile", transform.position);

    }

    private void jump()
    {
        foreach (SmallJelly item in smallJellies)
        {
            item.transform.DOLocalJump(item.transform.localPosition + Vector3.up * 5f, 5, 1, 1f)
                .OnComplete(() =>
                {
                    item.transform.DOLocalJump(item.transform.localPosition - Vector3.up * 5f, 10, 1, 1f);
                });
        }

    }

    private void toggleTrail(bool isActive)
    {
        trailObj.SetActive(isActive);
        trailObj.GetComponent<TrailRenderer>().enabled = isActive;
    }

    private IEnumerator bigGettingSmaller()
    {
        if(isGettingSmall)
        {
            while (true)
            {
                Vector3 newScale = bigJelly.transform.localScale - new Vector3(0.01f, 0.01f, 0.01f);
                bigJelly.transform.localScale = newScale;
                yield return new WaitForSeconds(0.1f);
            }
        }
    } 
}

public enum PlayerMode : int
{
    OneBig,
    ManySmall
}