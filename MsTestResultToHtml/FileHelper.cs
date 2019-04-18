using System;

namespace MsTestResultToHtml
{
    public static class FileHelper
    {
        #region 获取文件相对路径映射的物理路径
        /// <summary>
        /// 获取文件相对路径映射的物理路径，若文件为绝对路径则直接返回
        /// </summary>
        /// <param name="relativePath">文件的相对路径</param>        
        public static string GetPhysicalPath(string relativePath)
        {
            //有效性验证
            if (string.IsNullOrEmpty(relativePath))
            {
                return string.Empty;
            }
            //~,~/,/,\
            relativePath = relativePath.Replace("/", @"\").Replace("~", string.Empty).Replace("~/", string.Empty);
            //网络共享目录中的文件不应移除根路径
            if (!relativePath.StartsWith("\\\\"))
                relativePath = relativePath.StartsWith("\\") ? relativePath.Substring(1, relativePath.Length - 1) : relativePath;
            var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            var fullPath = System.IO.Path.Combine(path, relativePath);
            return fullPath;
        }
        #endregion

       
    }
}