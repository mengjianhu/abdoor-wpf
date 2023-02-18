using STTech.BytesIO.Serial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2022  All Rights Reserved.
 * 文 件 名:  Test
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2022/11/25 17:08:42
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2022/11/25 17:08:42
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace SerialPortCommunicationService
{
    public  class Test
    {
        SerialClient serialClient = new SerialClient();
        public Test()
        {
          
        }
        public void test()
        {
            SerialPortCommunicationHelp serialPortCommunicationHelp = new SerialPortCommunicationHelp(serialClient);
            serialClient.OnDataReceived += SerialClient_OnDataReceived;
        }

        private void SerialClient_OnDataReceived(object? sender, STTech.BytesIO.Core.DataReceivedEventArgs e)
        {
            
        }
    }
}
