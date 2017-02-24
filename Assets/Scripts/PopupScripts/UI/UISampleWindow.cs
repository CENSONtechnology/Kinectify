using UnityEngine;
using System.Collections;

public class UISampleWindow : UIWindow
{
    protected override void Setup()
    {
        Debug.Log("Updated window content.");
    }

    public void ShowFullVersionMessege()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.ConfirmExample, PrintFullVersionMessege, null);
    }

   
    private void PrintFullVersionMessege()
    {
        Debug.Log("Done");
    }

   
}