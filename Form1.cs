using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/**************************************************************************
开发人员：黄东明(donmine) 

本版本开发完成日期：2017-8-11

版本号：Version_NFC_1.11

备注：可用于基于PN532模块所进行的读写卡操作

使用方式：

             RX                          TX

  PC   UART  TX             TTL          RX          UART   PN532
                
             VCC(3.3V)                   VCC(3.3V)  
 
             GND                         GND


**************************************************************************/
namespace NFC
{
    public partial class NFC : Form
    {
        public NFC()
        {
            InitializeComponent();
        }
        private SerialPort sp = new SerialPort();
        public string modbusStatus;//端口状态
        private void readport_Click(object sender, EventArgs e)
        {
            cboPort.Items.Clear();//先清空端口列表
            if (SerialPort.GetPortNames() != null)
            {
                string[] ArrayPort = SerialPort.GetPortNames();
                for (int i = 0; i < ArrayPort.Length; i++)
                {
                    cboPort.Items.Add(ArrayPort[i]);
                }
            }
        }
        string port = "";
        private void connectport_Click_1(object sender, EventArgs e)
        {
            try
            {
                if(!sp.IsOpen)
                { 
                    port = cboPort.SelectedItem.ToString();
                    sp.PortName = port;
                    sp.BaudRate = 115200;
                    sp.StopBits = StopBits.One;
                    sp.Parity   = Parity.None;
                    sp.DataBits = 8;
                    if (port != "")
                    {
                        sp.Open();
                        if (sp.IsOpen)
                        MessageBox.Show("设备连接成功");
                    }
                }
                else MessageBox.Show("设备已连接成功，不需要再连接");
            }
            catch (Exception)
            {
                MessageBox.Show("设备连接异常");
            }
        }
        Boolean WakeFlag = false;
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] wake = new byte[]{ 0x55, 0x55, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xff, 0x03, 0xfd, 0xd4, 0x14, 0x01, 0x17, 0x00};
            byte[] wakecheck = new byte[]{ 0x00, 0x00, 0xFF, 0x00, 0xFF, 0x00, 0x00, 0x00, 0xFF, 0x02, 0xFE, 0xD5, 0x15, 0x16, 0x00 };    
            if (sp.IsOpen)
            {
                try
                {
                    sp.DiscardOutBuffer();
                    for (int i = 0; i < 3; i++)
                    {
                        sp.Write(wake, 0, wake.Length);
                        Thread.Sleep(1);
                    }
                    MessageBox.Show("唤醒数据发送成功！");
                    try
                    {
                        Byte[] ReceivedData = new Byte[sp.BytesToRead];
                        sp.Read(ReceivedData, 0, ReceivedData.Length);
                        for (int i = 0; i < wakecheck.Length; i++)
                        {
                            if (ReceivedData[i] != wakecheck[i])
                            {
                                 MessageBox.Show("唤醒失败，请重试！");
                                 return;
                            }
                        }
                        WakeFlag = true;
                        MessageBox.Show("唤醒成功，可进行下一步操作！");
                    }
                    catch
                    {
                        MessageBox.Show("请正确连接PN532模块后重试！");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("发送异常");
                }
            }
            else MessageBox.Show("请先打开串口连接设备");
        }

        byte[] UID = new byte [4];
        Boolean ReadFlag = false;
        private void ReadCardData_Click(object sender, EventArgs e)
        {
            byte[] cmdUID = new byte[]  { 0x00, 0x00, 0xFF, 0x04, 0xFC, 0xD4, 0x4A, 0x02, 0x00, 0xE0, 0x00};
            CardID.Text = "";
            if (WakeFlag)
            {
                if (sp.IsOpen)
                {
                    sp.DiscardInBuffer();
                    try
                    {
                        sp.DiscardOutBuffer();
                        sp.Write(cmdUID, 0, cmdUID.Length);
                        MessageBox.Show("读取卡ID号数据发送成功！");
                        try
                        {
                            Byte[] ReceivedData = new Byte[sp.BytesToRead];
                            sp.Read(ReceivedData, 0, ReceivedData.Length);
                            String RecvDataText = null;
                            for (int i = 19; i < 23; i++)
                            {
                                UID[i - 19] = ReceivedData[i];
                                RecvDataText += (ReceivedData[i].ToString("X2") + " ");
                            }
                            CardID.Text = RecvDataText;
                            ReadFlag = true;
                            MessageBox.Show("读取卡号成功！");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("请将卡贴近读写模块！");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("发送异常");
                    }
                }
                else MessageBox.Show("请先打开串口连接设备");
            }
            else MessageBox.Show("请先唤醒设备");
        }
        Boolean PassCheckFlag = false;
        private void PasswordCheck_Click(object sender, EventArgs e)
        {
            byte[] cmdPassWord = new byte[] { 0x00, 0x00, 0xFF, 0x0F, 0xF1, 0xD4, 0x40, 0x01, 0x60, 0x07, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF5, 0xC6, 0x4F, 0xBE, 0xC2, 0x00 };
            cmdPassWord[9] = 0x02;//验证第6块号,默认已是07
            byte[] key = new byte[] {0xff,0xff,0xff,0xff,0xff,0xff };
            byte sum = 0x00 ;
            byte  FF = 0xFF ;
            WriteData.Text = "";
            if (ReadFlag)
            {
                if (sp.IsOpen)
                {
                    sp.DiscardInBuffer();
                    try
                    {
                        for (int i = 10; i < 16; i++)
                        { 
                            cmdPassWord[i] = key[i - 10];// 密码
                        }
                        for (int i = 16; i < 20; i++)
                        {
                            cmdPassWord[i] = UID[i-16];
                        }
                        for (int i = 0; i < 20; i++)
                        { 
                            sum = (byte)(cmdPassWord[i] + sum);
                        }
                        cmdPassWord[20] = (byte)(FF - sum & FF);
                        sp.Write(cmdPassWord, 0, cmdPassWord.Length);

                        MessageBox.Show("密码验证数据发送成功！");
                        Byte[] ReceivedData = new Byte[sp.BytesToRead];
                        sp.Read(ReceivedData, 0, ReceivedData.Length);

                        if (ReceivedData[12] == 0x41 && ReceivedData[13] == 0x00) //密码验证成功
                        {
                            MessageBox.Show("密码验证成功！");
                            PassCheckFlag = true;
                        }              
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("发送异常");
                    }
                }
                else MessageBox.Show("请先打开串口连接设备");
            }
            else MessageBox.Show("请先唤醒设备");
        }
        private byte[] StringToHex(String s)
        {
            try
            {
                String sendData = s;
                sendData = sendData.Replace(" " , "");//去除16进制数据中所有空格  
                sendData = sendData.Replace("\r", "");//去除16进制数据中所有换行  
                sendData = sendData.Replace("\n", "");//去除16进制数据中所有换行
                sendData = sendData.Replace("0x", "");//去除0x
                sendData = sendData.Replace("0X", "");//去除0X
                sendData = sendData.Replace("," , "");//去除,
                sendData = sendData.Replace("，", "");//去除，
                if (sendData.Length == 1)//数据长度为1的时候，在数据前补0  
                {
                    sendData = "0" + sendData;
                }
                else if (sendData.Length % 2 != 0)//数据长度为奇数位时，去除最后一位数据  
                {
                    sendData = sendData.Remove(sendData.Length - 1, 1);
                }
                else if (sendData.Length % 2 != 0)//数据长度为奇数位时，去除最后一位数据  
                {
                    sendData = sendData.Remove(sendData.Length - 1, 1);
                }
                List<string> sendData16 = new List<string>();//将发送的数据，2个合为1个，然后放在该缓存里 如：123456→12,34,56  
                for (int i = 0; i < sendData.Length; i += 2)
                {
                    sendData16.Add(sendData.Substring(i, 2));
                }
                byte[] TransData = new byte[sendData16.Count];//sendBuffer的长度设置为：发送的数据2合1后的字节数  
                for (int i = 0; i < sendData16.Count; i++)
                {
                    TransData[i] = (byte)(Convert.ToInt32(sendData16[i], 16));//发送数据改为16进制  
                }
                return TransData;
            }
            catch
            {
                byte[] nul = new byte[] { 0x00 };
                return nul;
                MessageBox.Show("请不要输入特殊字符及其他非十六进制字母");
            }
        }
        private void WriteD_Click(object sender, EventArgs e)
        {
           // byte [] writeBuff = new byte[] { 0x11,0x01,0x02,0x03,0x04,0x05,0x06,0x07,0x08,0x09, 0x0A,0x0B, 0x0C, 0x0D ,0x0E, 0x0F };
            byte [] Hand = new byte[] { 0x00, 0x00, 0xff, 0x15, 0xEB, 0xD4, 0x40, 0x01, 0xA0, 0x02};//2块号
            byte [] DCS = new byte[] { 0xcd, 0x00 };
            byte [] writeBuff = StringToHex(WriteData.Text);
            int countLength = writeBuff.Length + Hand.Length + DCS.Length;
            byte [] count = new byte[countLength];
            byte sum = 0x00;
            byte FF = 0xFF;
            
            if (WriteData.Text == "")
            {
                MessageBox.Show("请先输入准备写入的数据");
            }
            else
            {
                if (PassCheckFlag)
                {
                    if (sp.IsOpen)
                    {
                        sp.DiscardInBuffer();
                        try
                        {
                            
                            for (int i = 0; i < Hand.Length; i++)//头部
                            {
                                count[i] = Hand[i];
                            }
                            for (int i = Hand.Length; i < writeBuff.Length + Hand.Length; i++)//数据
                            {
                                count[i] = writeBuff[i-Hand.Length];
                            }
                            for (int i= 0; i < writeBuff.Length + Hand.Length; i++)//DCS POSE
                            { 
                                sum = (byte)(count[i] + sum);
                            }
                            DCS[0] = (byte)(FF - sum & FF);
                            for (int i = 0; i < 2 ; i++)
                            {
                                count[i + writeBuff.Length + Hand.Length] = DCS[i];
                            }
                            sp.Write(count, 0, count.Length);

                            Byte[] ReceivedData = new Byte[sp.BytesToRead];
                            sp.Read(ReceivedData, 0, ReceivedData.Length);
                            String RecvDataText = null;
                            try
                            { 
                                for (int i = 0; i < ReceivedData.Length; i++)
                                {
                                    RecvDataText += (ReceivedData[i].ToString("X2") + " ");
                                }
                                WriteD.Text = RecvDataText;
                                if (ReceivedData[13] == 0x41 && ReceivedData[14] == 0x00) //密码验证成功
                                {
                                    MessageBox.Show("写入数据发送成功！");
                                }
                            }
                            catch (Exception)
                            {
                                sp.Close();
                                sp.Open();
                            }
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("接收异常");
                        }
                    }
                    else MessageBox.Show("请先打开串口连接设备");
                }
       
                else MessageBox.Show("请先进行密码验证");
            }
        }

        private void ReadD_Click(object sender, EventArgs e)
        {
            byte[] cmdRead = new byte[]{ 0x00, 0x00, 0xff, 0x05, 0xfb, 0xD4, 0x40, 0x01, 0x30, 0x00, 0x00, 0x00 };
            cmdRead[9]= 0x02;
            byte sum = 0x00;
            byte FF = 0xFF;
            ReadData.Text = "";
            if (PassCheckFlag)
            {
                if (sp.IsOpen)
                {
                    sp.DiscardInBuffer();
                    try
                    {
                        for (int i = 0; i <cmdRead.Length ; i++)
                        sum = (byte)(cmdRead[i] + sum);
                        cmdRead[10] = (byte)(FF - sum & FF);
                        sp.Write(cmdRead, 0, cmdRead.Length );
                        MessageBox.Show("读取数据发送成功！");

                        Byte[] ReceivedData = new Byte[sp.BytesToRead];
                        String RecvDataText = null;
                        sp.Read(ReceivedData, 0, ReceivedData.Length);
                        for (int i = 14; i < ReceivedData.Length-2; i++)//数据提取
                        {
                            RecvDataText += (ReceivedData[i].ToString("X2") + " ");
                        }
                        ReadData.Text += RecvDataText;
                        MessageBox.Show("读取成功");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("发送异常");
                    }
                }
                else MessageBox.Show("请先打开串口连接设备");
            }
            else MessageBox.Show("请先进行密码验证");
        }
        
        private void Test_Click(object sender, EventArgs e)
        {
            if(testw.Text=="")
            {
                MessageBox.Show("请先输入准备写入的数据");
            }
            else
            {
                if (sp.IsOpen)
                {
                    sp.DiscardInBuffer();
                    try
                    {
                        byte[] TransData = StringToHex(testw.Text);
                        sp.Write(TransData, 0, TransData.Length);
                        MessageBox.Show("测试数据发送成功！");

                        String RecvDataText = null;
                        Byte[] ReceivedData = new Byte[sp.BytesToRead];
                        sp.Read(ReceivedData, 0, ReceivedData.Length);
                        for (int i = 0; i < ReceivedData.Length; i++)//数据提取
                        {
                            RecvDataText += (ReceivedData[i].ToString("X2") + " ");
                        }
                        testr.Text = RecvDataText;
                    }
                    catch
                    {
                        MessageBox.Show("发送失败！");
                    }
                }
                else MessageBox.Show("请先连接设备！");
            }
        }

    }
}
