using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public abstract class UIWindow : MonoBehaviour, IWindow
{
    [SerializeField]
    private UIWindowBackground background;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string showTriggerName = "show";

    [SerializeField]
    private string closeTriggerName = "close";

    

    

 
    

    private void Start()
    {


        

        SetWindowActive(false);
    }

    public void Unhide()
    {
        Setup();
        SetWindowActive(true);
        animator.SetTrigger(showTriggerName);
        background.FadeIn();
    }

    public void Hide()
    {
        animator.SetTrigger(closeTriggerName);
        background.FadeOut();
        StartCoroutine(Tools.GetMethodName(DeactivateWindow));
    }

    public void Show()
    {
        Unhide();
        WindowsController.Instance.RegisterWindow(this);
    }

    public void Close()
    {
        WindowsController.Instance.DeleteNavigationHistory();
        Hide();
    }

    private IEnumerator DeactivateWindow()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        SetWindowActive(false);
    }

    private void SetWindowActive(bool active)
    {
        gameObject.SetActive(active);
        //background.gameObject.SetActive(active);
    }

    public void Back()
    {
        WindowsController.Instance.ReturnToLastWindow();
    }

    protected abstract void Setup();
}