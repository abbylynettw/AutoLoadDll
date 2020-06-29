using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;

namespace AllAutoCADLoadDll
{
    public partial class LoadDllForm : Form
    {
        public string AppPath = null;
        
        public LoadDllForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 返回系统中安装的AutoCAD版本列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAutoCADVersions()
        {
            //用于存储系统中安装的AutoCAD路径列表
            List<string> versions = new List<string>();
            // 获取HKEY_CURRENT_USER键
            RegistryKey keyCurrentUser = Registry.CurrentUser;
            // 打开AutoCAD所属的注册表键:HKEY_CURRENT_USER\Software\Autodesk\AutoCAD
            RegistryKey keyAutoCAD = keyCurrentUser.OpenSubKey("Software\\Autodesk\\AutoCAD");
            //获得表示系统中安装的各版本的AutoCAD注册表键
            string[] cadVersions = keyAutoCAD.GetSubKeyNames();
            foreach (string cadVersion in cadVersions)
            {
                string cadVerName = getVersionName(cadVersion);
                //如果版本在2007-2019
                if (cadVerName != "")
                {
                    //打开特定版本的AutoCAD注册表键
                    RegistryKey keyCADVersion = keyAutoCAD.OpenSubKey(cadVersion);
                    //获取表示各语言版本的AutoCAD注册表键值
                    string[] cadNames = keyCADVersion.GetSubKeyNames();
                    foreach (string cadName in cadNames)
                    {
                        if (cadName.EndsWith("804"))//中文版本
                        {
                            //获取到中文版本
                            versions.Add(cadVerName);
                            break;
                        }
                    }
                }
            }
            return versions;//返回系统中安装的AutoCAD版本列表
        }
        /// <summary>
        /// 根据CAD版本号获取CAD版本名称
        /// </summary>
        /// <param name="cadVersion"></param>
        /// <returns></returns>
        private static string getVersionName(string cadVersionCode)
        {
            string name = "";
            switch (cadVersionCode)
            {
                /*
                case "R16.0":
                    name = "CAD 2004";
                    break;
                case "R16.1":
                    name = "CAD 2005";
                    break;
                case "R16.2":
                    name = "CAD 2006";
                    break;
                    */
                case "R17.0":
                    name = "CAD 2007";
                    break;
                case "R17.1":
                    name = "CAD 2008";
                    break;
                case "R17.2":
                    name = "CAD 2009";
                    break;
                case "R18.0":
                    name = "CAD 2010";
                    break;
                case "R18.1":
                    name = "CAD 2011";
                    break;
                case "R18.2":
                    name = "CAD 2012";
                    break;
                case "R19.0":
                    name = "CAD 2013";
                    break;
                case "R19.1":
                    name = "CAD 2014";
                    break;
                case "R20.0":
                    name = "CAD 2015";
                    break;
                case "R20.1":
                    name = "CAD 2016";
                    break;
                case "R21.0":
                    name = "CAD 2017";
                    break;
                case "R22.0":
                    name = "CAD 2018";
                    break;
                case "R23.0":
                    name = "CAD 2019";
                    break;
                default:
                    name = "";
                    break;
            }
            return name;
        }
        /// <summary>
        /// 根据CAD版本名称获取CAD版本号
        /// </summary>
        /// <param name="verName"></param>
        /// <returns></returns>
        private string getVersionCode(string cadVersionName)
        {
            string name = "";
            switch (cadVersionName)
            {
                /*
                case "CAD 2004":
                    name = "R16.0";
                    break;
                case "CAD 2005":
                    name = "R16.1";
                    break;
                case "CAD 2006":
                    name = "R16.2";
                    break;
                    */
                case "CAD 2007":
                    name = "R17.0";
                    break;
                case "CAD 2008":
                    name = "R17.1";
                    break;
                case "CAD 2009":
                    name = "R17.2";
                    break;
                case "CAD 2010":
                    name = "R18.0";
                    break;
                case "CAD 2011":
                    name = "R18.1";
                    break;
                case "CAD 2012":
                    name = "R18.2";
                    break;
                case "CAD 2013":
                    name = "R19.0";
                    break;
                case "CAD 2014":
                    name = "R19.1";
                    break;
                case "CAD 2015":
                    name = "R20.0";
                    break;
                case "CAD 2016":
                    name = "R20.1";
                    break;
                case "CAD 2017":
                    name = "R21.0";
                    break;
                case "CAD 2018":
                    name = "R22.0";
                    break;
                case "CAD 2019":
                    name = "R23.0";
                    break;
                default:
                    name = "";
                    break;
            }
            return name;
        }
        /// <summary>
        /// 加载窗体时，显示已安装CAD版本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadDllForm_Load(object sender, EventArgs e)
        {
            //设定窗体位置
            this.Location = new Point(300, 150);

            //获取程序所在路径
            string filename = this.GetType().Assembly.Location;
            int index = filename.LastIndexOf("\\");
            string dir = filename.Substring(0, index);
            //string name = filename.Substring(index + 1);
            AppPath = dir;
            
            //获取系统中安装的AutoCAD列表
            List<string> cadVersionNames = GetAutoCADVersions();

            foreach (string cadVersionName in cadVersionNames)
            {
                //在列表框中显示系统中安装的AutoCAD
                this.listBoxAutoCAD.Items.Add(cadVersionName);
                //本地新建文件夹
                string bb = cadVersionName.Substring(cadVersionName.Length - 4);
                string bbDir = this.AppPath + "\\" + bb; //应用程序路径
                if (!Directory.Exists(bbDir))
                    Directory.CreateDirectory(bbDir);
            }
            if(listBoxAutoCAD.Items.Count>0)
                this.listBoxAutoCAD.SelectedIndex = 0;//设置列表框的选定项
            else
                MessageBox.Show("系统中未识别已安装的CAD软件！");
            
        }
        /// <summary>
        /// 获取指定CAD版本，中文版注册表键
        /// </summary>
        /// <param name="cadVersionCode"></param>
        /// <returns></returns>
        private RegistryKey GetAutoCADVersionsLanguage(string cadVersionCode)
        {
            RegistryKey keyLanguagePath = null;

            // 获取HKEY_CURRENT_USER键
            RegistryKey keyCurrentUser = Registry.CurrentUser;
            // 打开AutoCAD所属的注册表键:HKEY_CURRENT_USER\Software\Autodesk\AutoCAD
            RegistryKey keyAutoCAD = keyCurrentUser.OpenSubKey("Software\\Autodesk\\AutoCAD");
            //打开特定版本的AutoCAD注册表键 cadVersionCode
            RegistryKey keyCADVersion = keyAutoCAD.OpenSubKey(cadVersionCode);
            //获取表示各语言版本的AutoCAD注册表键值
            string[] cadNames = keyCADVersion.GetSubKeyNames();
            foreach (string cadName in cadNames)
            {
                if (cadName.EndsWith("804"))//中文版本
                {
                    //获取到中文版本，设定keyPath
                    keyLanguagePath = keyCADVersion.OpenSubKey(cadName);
                    break;
                }
            }
            return keyLanguagePath;//返回系统中安装的AutoCAD版本列表
        }
        /// <summary>
        /// 将DLL程序添加到注册表
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="appDesc"></param>
        /// <param name="appPath"></param>
        /// <param name="currentUser"></param>
        /// <param name="overwrite"></param>
        /// <param name="flagLOADCTRLS"></param>
        /// <returns></returns>
        private bool CreateDemandLoadingEntries(string cadVersionCode,string appName, string appDesc, string appPath, bool overwrite, int flagLOADCTRLS)
        {
            //获取AutoCAD所属的注册表键名
            RegistryKey keyLanguagePath = GetAutoCADVersionsLanguage(cadVersionCode);
            if (keyLanguagePath == null) return false;
            string autoCADKeyName = keyLanguagePath.Name.Substring(Registry.CurrentUser.Name.Length + 1);

            //确定是HKEY_CURRENT_USER
            RegistryKey keyRoot = Registry.CurrentUser;

            // 由于某些AutoCAD版本的HKEY_CURRENT_USER可能不包括Applications键值，因此要创建该键值
            // 如果已经存在该鍵，无须担心可能的覆盖操作问题，因为CreateSubKey函数会以写的方式打开它而不会执行覆盖操作
            RegistryKey keyApp = keyRoot.CreateSubKey(autoCADKeyName + "\\" + "Applications");
            //若存在同名的程序且选择不覆盖则返回
            if (!overwrite && keyApp.GetSubKeyNames().Contains(appName))
                return false;

            //创建相应的键并设置自动加载应用程序的选项
            RegistryKey keyUserApp = keyApp.CreateSubKey(appName);
            keyUserApp.SetValue("DESCRIPTION", appDesc, RegistryValueKind.String);
            keyUserApp.SetValue("LOADCTRLS", flagLOADCTRLS, RegistryValueKind.DWord);
            keyUserApp.SetValue("LOADER", appPath, RegistryValueKind.String);
            keyUserApp.SetValue("MANAGED", 1, RegistryValueKind.DWord);
            return true;//创建键成功则返回
        }
        /// <summary>
        /// 删除注册表
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        public bool RemoveDemandLoadingEntries(string cadVersionCode,string appName)
        {
            try
            {
                //获取AutoCAD所属的注册表键名
                RegistryKey keyLanguagePath = GetAutoCADVersionsLanguage(cadVersionCode);
                if (keyLanguagePath == null) return false;
                string cadName = keyLanguagePath.Name.Substring(Registry.CurrentUser.Name.Length + 1);
                //确定是HKEY_CURRENT_USER
                RegistryKey keyRoot = Registry.CurrentUser;

                // 以写的方式打开Applications注册表键
                RegistryKey keyApp = keyRoot.OpenSubKey(cadName + "\\" + "Applications", true);
                RegistryKey app = keyApp.OpenSubKey(appName);
                if(app != null)
                    //删除指定名称的注册表键
                    keyApp.DeleteSubKeyTree(appName);
                //else MessageBox.Show("未发现注册表项");
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 加载按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_load_Click(object sender, EventArgs e)
        {
            //加载DLL
            int selCount = listBoxAutoCAD.SelectedItems.Count;
            if (selCount == 0) return;
            int err = 0;
            
            string appName = this.textBox_AppName.Text; //应用程序名
            string appDesc = this.textBox_AppDesc.Text; //应用描述

            //遍历listbox
            foreach (object selectItem in listBoxAutoCAD.SelectedItems)
            {
                string cadVersionName = selectItem.ToString();
                string cadVersionCode = getVersionCode(cadVersionName);
                string bb = cadVersionName.Substring(cadVersionName.Length - 4);
                string dllFileName = this.AppPath + "\\" + bb + "\\" + appName ; //应用程序路径

                if (File.Exists(dllFileName))
                {
                    //添加注册表项到Applications键下
                    if (!CreateDemandLoadingEntries(cadVersionCode, appName, appDesc, dllFileName, true, 2))
                    {
                        MessageBox.Show(cadVersionName + " " + appName + " 加载失败!");
                        err++;
                    }
                }
                else
                {
                    MessageBox.Show(" 未找到文件: "+dllFileName);
                    err++;
                }
            }
            if (err == 0)
                MessageBox.Show("加载成功!");
            else
                MessageBox.Show("加载结束！共发现" + err.ToString()+"个问题!");
        }
        /// <summary>
        /// 卸载按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_unload_Click(object sender, EventArgs e)
        {
            //卸载DLL
            int selCount = listBoxAutoCAD.SelectedItems.Count;
            if (selCount == 0) return;
            int err = 0;
            string appName = this.textBox_AppName.Text; //应用程序名
            string appDesc = this.textBox_AppDesc.Text; //应用描述

            //要卸载的程序名
            string text = this.textBox_AppName.Text;

            //遍历listbox
            foreach (object selectItem in listBoxAutoCAD.SelectedItems)
            {
                string cadVersionName = selectItem.ToString();
                string cadVersionCode = getVersionCode(cadVersionName);
                
                if (!RemoveDemandLoadingEntries(cadVersionCode, text)) //删除成功
                {
                    MessageBox.Show(cadVersionName + " " + text + " 卸载失败!");
                    err++;
                }
            }
            if(err==0)
                MessageBox.Show("卸载成功!");
            else
                MessageBox.Show("卸载结束，共发现" + err.ToString()+"个问题!");
        }
    }
}
