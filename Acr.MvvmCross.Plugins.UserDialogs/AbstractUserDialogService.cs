﻿using System;
using System.Threading.Tasks;


namespace Acr.MvvmCross.Plugins.UserDialogs {
    
    public abstract class AbstractUserDialogService : IUserDialogService {

        public abstract void ActionSheet(string title, params SheetOption[] options);
        public abstract void Alert(string message, string title, string okText, Action onOk);
        public abstract void Confirm(string message, Action<bool> onConfirm, string title, string okText, string cancelText);
        public abstract void Prompt(string message, Action<PromptResult> promptResult, string title, string okText, string cancelText, string hint);
        public abstract void Toast(string message, int timeoutSeconds, Action onClick);
        public abstract IProgressDialog Progress(string title, Action onCancel, string cancelText, bool show);
        public abstract IProgressDialog Loading(string title, Action onCancel, string cancelText, bool show);        
        public abstract void ShowLoading(string title);
        public abstract void HideLoading();

        public Task AlertAsync(string message, string title, string okText) {
            var tcs = new TaskCompletionSource<object>();
            this.Alert(message, title, okText, () => tcs.SetResult(null));
            return tcs.Task;
        }


        public Task<bool> ConfirmAsync(string message, string title, string okText, string cancelText) {
            var tcs = new TaskCompletionSource<bool>();
            this.Confirm(message, tcs.SetResult, title, okText, cancelText);
            return tcs.Task;
        }


        public Task<PromptResult> PromptAsync(string message, string title, string okText, string cancelText, string hint) {
            var tcs = new TaskCompletionSource<PromptResult>();
            this.Prompt(message, tcs.SetResult, title, okText, cancelText, hint);
            return tcs.Task;
        }
    }
}