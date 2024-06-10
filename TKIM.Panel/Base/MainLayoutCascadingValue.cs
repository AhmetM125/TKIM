using Blazored.LocalStorage;
using Blazored.Toast.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace TKIM.Panel.Base;

public class MainLayoutCascadingValue
{
    private readonly IToastService _toast;
    private readonly IJSRuntime _js;
    private readonly ILocalStorageService _localStorage;
    private readonly IServiceScopeFactory _scopeFactory;

    public string LocalStorageKey { get; } = "Company_Key";
    public MainLayoutCascadingValue(IToastService toast,
     IJSRuntime js,
     ILocalStorageService localStorage,
     IServiceScopeFactory scopeFactory,
     NavigationManager navigator)
    {
        _toast = toast;
        _js = js;
        _localStorage = localStorage;
        _scopeFactory = scopeFactory;
    }

    public async Task OpenModal(string id)
    {
        try
        {
            await _js.InvokeVoidAsync("openModal", id);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }
    public async Task CloseModal(string id)
    {
        try
        {
            await _js.InvokeVoidAsync("closeModal", id);
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message, MessageType.Error);
        }
    }

    public void ShowMessage(string message, MessageType messageType = MessageType.Success)
    {
        switch (messageType)
        {
            case MessageType.Error:
                _toast.ShowError(message);
                break;
            case MessageType.Warning:
                _toast.ShowWarning(message);
                break;
            case MessageType.Success:
                _toast.ShowSuccess(message);
                break;
            case MessageType.Info:
                _toast.ShowInfo(message);
                break;
            default:
                break;
        }
    }
    public void ShowMessage(List<ValidationFailure> errors)
    {
        var message = string.Join("\n", errors.Select(x => $"* {x.ErrorMessage}"));
        _toast.ShowError(message);
    }


    public async Task<string> GetCompany()
    {
        return await _localStorage.GetItemAsync<string>(LocalStorageKey) ?? "";
    }

    public async Task SetCompany(string company)
    {
        await _localStorage.SetItemAsync(LocalStorageKey, company);
    }
}
