using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ChromiumWrapBrowser : Form
    {
        public ChromiumWrapBrowser()
        {
            InitializeComponent();
            InitializeChromeBrowser();
        }

        private void InitializeChromeBrowser()
        {
            CefSettings cefSettings = new CefSettings();
            Cef.Initialize(cefSettings);
            ChromiumWebBrowser chrome = new ChromiumWebBrowser("https://www.daum.net/");
            chrome.Dock = DockStyle.Fill;
            // From창에 ChrominumWebCrowser 가득 채우기 
            this.Controls.Add(chrome);

            //JavascriptBindingExtensions Event 호출 활성화
            chrome.JavascriptObjectRepository.Settings.LegacyBindingEnabled = true;
            chrome.JavascriptObjectRepository.Register("ChromeAPI", new ChromeAPI(), false, BindingOptions.DefaultBinder);

            
        }
    }

    //https://blog.edit.kr/entry/C%EC%97%90%EC%84%9C-Chrome-%EB%B8%8C%EB%9D%BC%EC%9A%B0%EC%A0%80-%EC%82%AC%EC%9A%A9-%EC%9B%B9-%EC%86%8C%EC%8A%A4%EC%97%90%EC%84%9C-%EC%9E%90%EB%B0%94%EC%8A%A4%ED%81%AC%EB%A6%BD%ED%8A%B8%EB%A1%9C-C-%ED%95%A8%EC%88%98-%ED%98%B8%EC%B6%9C%ED%95%98%EA%B8%B0-CEFSharp-Chromium
    internal class ChromeAPI
    {
        public void showMsg(string msg)
        {
            MessageBox.Show(msg);
        }
    }
}
