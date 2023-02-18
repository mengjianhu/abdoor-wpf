using STTech.BytesIO.Core;
using STTech.BytesIO.Serial;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  SerialPortCommunicationHelp
 * 描    述:  用于串口之间通信的类
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/25 15:46:38
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/25 15:46:38
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace SerialPortCommunicationService
{
    public class SerialPortCommunicationHelp
    {
        private SerialClient client =null;
     
        public SerialPortCommunicationHelp(SerialClient client)
        {
           
            if (client == null)
            {
                throw new ArgumentNullException("SerialClient参数 不能为空");
            }
            this.client = client;
            //client.OnDataReceived += Client_OnDataReceived;
            //client.OnConnectedSuccessfully += Client_OnConnectedSuccessfully;
            //client.OnDisconnected += Client_OnDisconnected;
            //client.OnDataSent += Client_OnDataSent;
        }
        /// <summary>
        /// 断开连接
        /// </summary>
        public async void Disconnect()
        {
            await client.DisconnectAsync();
        }
        /// <summary>
        /// 连接
        /// </summary>
        /// <returns>bool</returns>
        public async Task<bool> ConnectAsync()
        {
            ConnectResult result = await client.ConnectAsync();
            if (result != null)
            {
                if (result.IsSuccess)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        /// <summary>
        /// 断开连接(异步）
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DisConnectAsync()
        {
            DisconnectResult result = await client.DisconnectAsync();
            if (result != null)
            {
                if (result.IsSuccess)
                {
                    return true;
                }
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Exception.Message);
                return false;
            }
            return false;
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg">需要发送的消息</param>
        public async void SendMessageAsync(string msg)
        {
             await  client.SendAsync(msg.GetBytes("GBK"));
        }
       
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Client_OnDataSent(object? sender, DataSentEventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 断开连接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>

        private void Client_OnDisconnected(object? sender, DisconnectedEventArgs e)
        {
            
        }
        /// <summary>
        /// 成功连接事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Client_OnConnectedSuccessfully(object? sender, ConnectedSuccessfullyEventArgs e)
        {

        }
        /// <summary>
        /// 接收消息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Client_OnDataReceived(object? sender, DataReceivedEventArgs e)
        //{
        //    // 处理消息
        //    string receiveMsg = e.Data.EncodeToString("GBK");//接收到的消息
        //}
    }
}
