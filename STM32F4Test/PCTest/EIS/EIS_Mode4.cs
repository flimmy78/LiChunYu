﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PCTest
{
    public class EIS_Mode4_ReadData
    {
        public CANCommand[] canCommand=new CANCommand[1+1+46*3];
        public EIS_Mode4_ReadData()
        {
            canCommand[0] = new CANCommand();
            canCommand[0].bTxOnly = 1;
            canCommand[0].TxStdId = 0x612;
            canCommand[0].TxData = new byte[] { 0x02, 0x10, 0x92, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            canCommand[0].TxRetry = 50;
            canCommand[0].TxTimeOut = 1;

            /************************************************************************/
            /* 握手                                                                 */
            /************************************************************************/
            canCommand[1] = new CANCommand();
            canCommand[1].TxStdId = 0x612;
            canCommand[1].TxData = new byte[] { 0x02, 0x10, 0x92, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            canCommand[1].TxRetry = 50;
            canCommand[1].TxTimeOut = 1;

            canCommand[1].NeedStdId = 0x482;
            canCommand[1].RxRetry = 3;
            canCommand[1].RxTimeOut = 500;

            for (int i = 0; i < 46; i++)
            {
                canCommand[2 + i * 3] = new CANCommand();
                canCommand[2 + i * 3].TxStdId = 0x612;
                canCommand[2 + i * 3].TxData = new byte[] { 0x04, 0x31, 0x22, 0x6F, 0x00, 0xFF, 0xFF, 0xFF };
                //命令字
                canCommand[2 + i * 3].TxData[4] = (byte)(i);

                canCommand[2 + i * 3].TxRetry = 10;
                canCommand[2 + i * 3].TxTimeOut = 10;

                canCommand[2 + i * 3].NeedStdId = 0x482;
                canCommand[2 + i * 3].RxRetry = 3;
                canCommand[2 + i * 3].RxTimeOut = 500;



                canCommand[2 + i * 3+1] = new CANCommand();
                canCommand[2 + i * 3+1].TxStdId = 0x612;
                canCommand[2 + i * 3 + 1].TxData = new byte[] { 0x04, 0x31, 0x22, 0x6F, 0x00, 0xFF, 0xFF, 0xFF };
                //命令字
                canCommand[2 + i * 3 + 1].TxData[4] =(byte)(i);

                canCommand[2 + i * 3+1].TxRetry = 10;
                canCommand[2 + i * 3+1].TxTimeOut = 10;

                canCommand[2 + i * 3 + 1].NeedStdId = 0x482;
                canCommand[2 + i * 3 + 1].RxRetry = 3;
                canCommand[2 + i * 3 + 1].RxTimeOut = 500;


                canCommand[2 + i * 3 + 2] = new CANCommand();
                canCommand[2 + i * 3 + 2].TxStdId = 0x612;
                canCommand[2 + i * 3 + 2].TxData = new byte[] { 0x30, 0x08, 0x28, 0x00, 0x00, 0x00, 0x00, 0x00 };
                canCommand[2 + i * 3 + 2].TxRetry = 10;
                canCommand[2 + i * 3 + 2].TxTimeOut = 10;

                canCommand[2 + i * 3 + 2].NeedStdId = 0x482;
                canCommand[2 + i * 3 + 2].RxRetry = 3;
                canCommand[2 + i * 3 + 2].RxTimeOut = 500;
            }
        }
    }
}
