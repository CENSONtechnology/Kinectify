using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class UISampleWindow : UIWindow
{
    protected override void Setup()
    {
        Debug.Log("Updated window content.");
    }

    public void ShowFullVersionMessege()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.FullVersion, PrintFullVersionMessege, null);
    }
    public void LoginSucsessful()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.SucsessfulLogin, PrintFullVersionMessege,null,true);
        

    }

    public void Username()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.username, PrintFullVersionMessege, null);
    }
    public void Password()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.password, PrintFullVersionMessege, null);
    }
    public void ConfirmPassword()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.confirmpassword, PrintFullVersionMessege, null);
    }
    public void testConfirmPassword()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.testconfirm, PrintFullVersionMessege, null);
    }
    public void PhoneNumber()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.phone, PrintFullVersionMessege, null);
    }
    public void Age()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.age, PrintFullVersionMessege, null);
    }
    public void Gender()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.gendar, PrintFullVersionMessege, null);
    }
    public void Email()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.email, PrintFullVersionMessege, null);
    }
    public void FirstName()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.firstname, PrintFullVersionMessege, null);
    }
    public void LastName()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.lastname, PrintFullVersionMessege, null);
    }
    public void Notes()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.notes, PrintFullVersionMessege, null);
    }
    public void loginfail1()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.loginfilled1, PrintFullVersionMessege, null);
    }
    public void loginfail2()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.loginfilled2, PrintFullVersionMessege, null);
    }
    public void serverError()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.serverError, PrintFullVersionMessege, null);
    }

    public void DoneLevel()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.Done, Success, null);
    }

    private void Success()
    {
        LoadingScreenManager.LoadScene(8);
    }
    public void DoneLevellogin()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.Done, successlevel, null);
    }
    private void successlevel()
    {
        LoadingScreenManager.LoadScene(7);
    }
    public void Donegame()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.Done, game, null);
    }
    private void game()
    {
        LoadingScreenManager.LoadScene(13);
    }
    public void Donegym()
    {
        WindowsController.Instance.PopupController.Show(PopupDefinitions.Done, gym, null);
    }
    private void gym()
    {
        LoadingScreenManager.LoadScene(1);
    }

    private void PrintFullVersionMessege()
    {
        Debug.Log("Done");
    }

   
}