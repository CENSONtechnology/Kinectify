using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    private Action confirm;
    private Action cancel;

    [SerializeField]
    private UIWindowBackground background;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private string showTriggerName = "show";

    [SerializeField]
    private string closeTriggerName = "close";

    

    

    [SerializeField]
    private Text confirmButtonText;

    [SerializeField]
    private Text cancelButtonText;

    private void Start()
    {
        SetPopupActive(false);
    }

    public void Setup( string confirmText, Action confirm, Action cancel)
    {
        Show();

   
        this.confirm = confirm;
        this.cancel = cancel;
        this.confirmButtonText.text = confirmText;
        

        
    }

    private void Show()
    {
        SetPopupActive(true);
        animator.SetTrigger(showTriggerName);
        background.FadeIn();
    }

    public void Confirm()
    {
        if(confirm != null)
            confirm();

        Close();
    }

    public void Cancel()
    {
        if(cancel != null)
            cancel();

        Close();
    }

    private void Close()
    {
        animator.SetTrigger(closeTriggerName);
        background.FadeOut();
        StartCoroutine(Tools.GetMethodName(DeactivateWindow));
    }                               

    private IEnumerator DeactivateWindow()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        SetPopupActive(false);
    }

    private void SetPopupActive(bool active)
    {
        gameObject.SetActive(active);
        background.gameObject.SetActive(active);
    }
}