/* MIT License

Copyright (c) 2018 Binwell https://binwell.com

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using XamarinMobileApp.BL.ViewModels;
using XamarinMobileApp.Helpers;
using XamarinMobileApp.UI.Pages;

namespace XamarinMobileApp.UI
{
    public sealed class NavigationService
    {
        static readonly Lazy<NavigationService> LazyInstance = new Lazy<NavigationService>(() => new NavigationService(), true);

        readonly Dictionary<string, Type> _pageTypes;
        readonly Dictionary<string, Type> _viewModelTypes;

        NavigationService()
        {
            _pageTypes = GetAssemblyPageTypes();
            _viewModelTypes = GetAssemblyViewModelTypes();
            MessagingCenter.Subscribe<MessageBus, NavigationPushInfo>(this, Consts.NavigationPushMessage, NavigationPushCallback);
            MessagingCenter.Subscribe<MessageBus, NavigationPopInfo>(this, Consts.NavigationPopMessage, NavigationPopCallback);
        }

        public static void Init(XamarinMobileApp.Helpers.Pages detail)
        {
            Instance.Initialize(detail);
        }

        private void Initialize(XamarinMobileApp.Helpers.Pages page)
        {
            var initPage = GetInitializedPage(page.ToString());
            RootPush(initPage);
        }

        public static NavigationService Instance => LazyInstance.Value;

        private void NavigationPushCallback(MessageBus bus, NavigationPushInfo navigationPushInfo)
        {
            if (navigationPushInfo == null) throw new ArgumentNullException(nameof(navigationPushInfo));

            if (string.IsNullOrEmpty(navigationPushInfo.To)) throw new FieldAccessException(@"'To' page value should be set");

            Push(navigationPushInfo);
        }

        private void NavigationPopCallback(MessageBus bus, NavigationPopInfo navigationPopInfo)
        {
            if (navigationPopInfo == null) throw new ArgumentNullException(nameof(navigationPopInfo));

            Pop(navigationPopInfo);
        }

        private INavigation GetTopNavigation()
        {
            var mainPage = Xamarin.Forms.Application.Current.MainPage;

            if (mainPage is MasterDetailPage masterDetailPage)
            {
                if (masterDetailPage.Detail is NavigationPage navigationPage)
                {
                    var modalStack = navigationPage.Navigation.ModalStack.OfType<NavigationPage>().ToList();
                    if (modalStack.Any())
                    {
                        return modalStack.LastOrDefault()?.Navigation;
                    }
                    return navigationPage.Navigation;
                }
            }

            return (mainPage as NavigationPage)?.Navigation;
        }

        private void Push(NavigationPushInfo pushInfo)
        {
            var newPage = GetInitializedPage(pushInfo);

            switch (pushInfo.Mode)
            {
                case NavigationMode.Normal:
                    NormalPush(newPage, pushInfo.OnCompletedTask);
                    break;
                case NavigationMode.Modal:
                    ModalPush(newPage, pushInfo.OnCompletedTask, pushInfo.NewNavigationStack);
                    break;
                case NavigationMode.RootPage:
                    RootPush(newPage, pushInfo.OnCompletedTask);
                    break;
                case NavigationMode.Custom:
                    CustomPush(newPage, pushInfo.OnCompletedTask);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void NormalPush(Page newPage, TaskCompletionSource<bool> completed)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await GetTopNavigation().PushAsync(newPage, true);
                    completed.SetResult(true);
                }
                catch
                {
                    completed.SetResult(false);
                }
            });
        }

        private void ModalPush(Page newPage, TaskCompletionSource<bool> completed, bool newNavigationStack = true)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    if (newNavigationStack) newPage = new NavigationPage(newPage);
                    await GetTopNavigation().PushModalAsync(newPage, true);
                    completed.SetResult(true);
                }
                catch
                {
                    completed.SetResult(false);
                }
            });
        }

        void RootPush(Page newPage, TaskCompletionSource<bool> pushInfoOnCompletedTask = null)
        {
            Device.BeginInvokeOnMainThread(async () => {
                try
                {
                    if (Xamarin.Forms.Application.Current.MainPage == null || Xamarin.Forms.Application.Current.MainPage is SignInPage)
                    {
                        if (newPage is SignInPage)
                        {
                            Xamarin.Forms.Application.Current.MainPage = newPage;
                        }
                        else
                        {
                            Xamarin.Forms.Application.Current.MainPage = new NavigationPage(newPage);
                        }
                    }
                    else if (Xamarin.Forms.Application.Current.MainPage is NavigationPage navigationPage)
                    {
                        var navigation = navigationPage.Navigation;
                        var navigationStack = navigationPage.Navigation.NavigationStack;
                        if (navigationStack.Any())
                        {
                            navigation.InsertPageBefore(newPage, navigationStack.FirstOrDefault());
                            await navigation.PopToRootAsync();
                        }
                        pushInfoOnCompletedTask?.SetResult(true);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    pushInfoOnCompletedTask?.SetResult(false);
                }
            });

        }

        private void CustomPush(Page newPage, TaskCompletionSource<bool> pushInfoOnCompletedTask)
        { }

        private void Pop(NavigationPopInfo popInfo)
        {
            switch (popInfo.Mode)
            {
                case NavigationMode.Normal:
                    NormalPop(popInfo.OnCompletedTask);
                    break;
                case NavigationMode.Modal:
                    ModalPop(popInfo.OnCompletedTask);
                    break;
                case NavigationMode.Custom:
                    CustomPop(popInfo.OnCompletedTask);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void ModalPop(TaskCompletionSource<bool> completed)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await GetTopNavigation().PopModalAsync();
                    completed.SetResult(true);
                }
                catch
                {
                    completed.SetResult(false);
                }
            });
        }

        private void CustomPop(TaskCompletionSource<bool> completed)
        { }

        private void NormalPop(TaskCompletionSource<bool> completed)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await GetTopNavigation().PopAsync();
                    completed.SetResult(true);
                }
                catch
                {
                    completed.SetResult(false);
                }
            });
        }

        private static string GetTypeBaseName(MemberInfo info)
        {
            if (info == null) throw new ArgumentNullException(nameof(info));

            return info.Name.Replace(@"Page", "").Replace(@"ViewModel", "");
        }

        private static Dictionary<string, Type> GetAssemblyPageTypes() =>
            typeof(BasePage).GetTypeInfo().Assembly.DefinedTypes
                .Where(ti => ti.IsClass && !ti.IsAbstract && ti.Name.Contains(@"Page") && ti.BaseType.Name.Contains(@"Page"))
                .ToDictionary(GetTypeBaseName, ti => ti.AsType());

        private static Dictionary<string, Type> GetAssemblyViewModelTypes() => 
            typeof(BaseViewModel).GetTypeInfo().Assembly.DefinedTypes
                .Where(ti => ti.IsClass && !ti.IsAbstract && ti.Name.Contains(@"ViewModel") &&
                ti.BaseType.Name.Contains(@"ViewModel"))
                .ToDictionary(GetTypeBaseName, ti => ti.AsType());
     

        private BasePage GetInitializedPage(string toName, Dictionary<string, object> navParams = null)
        {
            var page = GetPage(toName);
            var viewModel = GetViewModel(toName);
            viewModel.SetNavigationParams(navParams);
            page.BindingContext = viewModel;
            return page;
        }

        private Page GetInitializedPage(NavigationPushInfo navigationPushInfo) => 
            GetInitializedPage(navigationPushInfo.To, navigationPushInfo.NavigationParams);

        private BasePage GetPage(string pageName)
        {
            if (!_pageTypes.ContainsKey(pageName)) throw new KeyNotFoundException($@"Page for {pageName} not found");
            BasePage page;
            try
            {
                var pageType = _pageTypes[pageName];
                var pageObject = Activator.CreateInstance(pageType);
                page = pageObject as BasePage;
            }
            catch (Exception e)
            {
                throw new TypeLoadException($@"Unable create instance for {pageName}Page", e);
            }

            return page;
        }

        private BaseViewModel GetViewModel(string pageName)
        {
            if (!_viewModelTypes.ContainsKey(pageName)) throw new KeyNotFoundException($@"ViewModel for {pageName} not found");

            BaseViewModel viewModel;
            try
            {
                viewModel = Activator.CreateInstance(_viewModelTypes[pageName]) as BaseViewModel;
            }
            catch (Exception e)
            {
                throw new TypeLoadException($@"Unable create instance for {pageName}ViewModel", e);
            }

            return viewModel;
        }
    }

    public class NavigationPushInfo
    {
        public string From { get; set; }
        public string To { get; set; }
        public Dictionary<string, object> NavigationParams { get; set; }
        public NavigationMode Mode { get; set; } = NavigationMode.Normal;
        public bool NewNavigationStack { get; set; }
        public TaskCompletionSource<bool> OnCompletedTask { get; set; }
    }

    public class NavigationPopInfo
    {
        public NavigationMode Mode { get; set; } = NavigationMode.Normal;
        public TaskCompletionSource<bool> OnCompletedTask { get; set; }
        public string To { get; set; }
    }
}