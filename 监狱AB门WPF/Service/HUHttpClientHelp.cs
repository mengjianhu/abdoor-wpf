using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  HUHttpClientHelp
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/28 16:34:20
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/28 16:34:20
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace 监狱AB门WPF.Service
{
    /// <summary>
    /// httpclient 请求
    /// </summary>
    public static class HUHttpClientHelp
    {
        static HttpClient httpClient = new HttpClient();
        /// <summary>
        /// Get 请求
        /// 2022/10/22
        /// </summary>
        /// <returns></returns>
        public static async Task<string> HTTPGET()
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.RequestUri = new Uri("https://github.com/");
            var response = await httpClient.SendAsync(httpRequestMessage);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
        public static async Task<string> Post(string postData, string url)
        {
            using(HttpClient httpClient=new HttpClient())
            {
                string result = null;
                try
                {
                    HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                    httpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");
                    var response = await httpClient.SendAsync(httpRequestMessage);
                    result = await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"网络错误:{ex.Message}！", "提示");
                    return null;
                }
                return result;
            }
           
        }
        /// <summary>
        /// 分页 查询 
        /// 通过URL 传参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public async static Task<string> WebApiPostAsync(string url, Dictionary<string, int> para)
        {

            string content = null;
            StringBuilder parastr = new StringBuilder("?");
            foreach (var item in para)
            {
                parastr.Append(item.Key);
                parastr.Append("=");
                parastr.Append(item.Value);
                parastr.Append("&");
            }
            string paraResult = parastr.ToString().TrimEnd('&');
            using (HttpClient httpclient = new HttpClient())
            {
                HttpRequestMessage msg = new HttpRequestMessage();
                msg.Method = HttpMethod.Post;
                msg.RequestUri = new Uri(url + paraResult);
                try
                {
                    var result = await httpclient.SendAsync(msg);
                    content = await result.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"网络错误:{ex.Message}！", "提示");
                }
            }
            return content;

        }


        public async static Task<string> WebApiGetAsync(string url, Dictionary<string, int> para)
        {

            string content = null;
            StringBuilder parastr = new StringBuilder("?");
            foreach (var item in para)
            {
                parastr.Append(item.Key);
                parastr.Append("=");
                parastr.Append(item.Value);
                parastr.Append("&");
            }
            string paraResult = parastr.ToString().TrimEnd('&');
            using (HttpClient httpclient = new HttpClient())
            {
                HttpRequestMessage msg = new HttpRequestMessage();
                msg.Method = HttpMethod.Get;
                msg.RequestUri = new Uri(url + paraResult);
                try
                {
                    var result = await httpclient.SendAsync(msg);
                    content = await result.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"网络错误:{ex.Message}！", "提示");
                }
            }
            return content;

        }
        /// <summary>
        /// 分页 查询 
        /// 通过URL 传参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public async static Task<string> WebApiPostAsync(string url, Dictionary<string, string> para)
        {

            string content = null;
            StringBuilder parastr = new StringBuilder("?");
            foreach (var item in para)
            {
                parastr.Append(item.Key);
                parastr.Append("=");
                parastr.Append(item.Value);
                parastr.Append("&");
            }
            string paraResult = parastr.ToString().TrimEnd('&');
            using (HttpClient httpclient = new HttpClient())
            {
                HttpRequestMessage msg = new HttpRequestMessage();
                msg.Method = HttpMethod.Post;
                msg.RequestUri = new Uri(url + paraResult);
                try
                {
                    var result = await httpclient.SendAsync(msg);
                    content = await result.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"网络错误:{ex.Message}！", "提示");
                }
            }
            return content;

        }
        public static async Task<string> PostWithToken(string url, string postData, string oken)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, url);
            httpRequestMessage.Content = new StringContent(postData, Encoding.UTF8, "application/json");
            var response = await httpClient.SendAsync(httpRequestMessage);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }


    }
}

