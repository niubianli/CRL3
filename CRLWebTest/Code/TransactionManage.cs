/**
* CRL 快速开发框架 V4.0
* Copyright (c) 2016 Hubro All rights reserved.
* GitHub https://github.com/hubro-xx/CRL3
* 主页 http://www.cnblogs.com/hubro
* 在线文档 http://crl.changqidongli.com/
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Code
{
    /// <summary>
    /// 交易流水管理
    /// </summary>
    public class TransactionManage : CRL.Package.Account.TransactionBusiness<TransactionManage>
    {
        public static TransactionManage Instance
        {
            get { return new TransactionManage(); }
        }

    }
}
