﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CRL.LambdaQuery.CRLExpression
{
    /// <summary>
    /// CRLExpression节点
    /// </summary>
    public class CRLExpression
    {
        public override string ToString()
        {
            return CoreHelper.StringHelper.SerializerToJson(this);
        }
        /// <summary>
        /// 左节点
        /// </summary>
        public CRLExpression Left
        {
            get;
            set;
        }
        /// <summary>
        /// 右节点
        /// </summary>
        public CRLExpression Right
        {
            get;
            set;
        }
        /// <summary>
        /// 节点类型
        /// </summary>
        public CRLExpressionType Type
        {
            get;
            set;
        }
        /// <summary>
        /// 数据
        /// </summary>
        public object Data
        {
            get;
            set;
        }
        /// <summary>
        /// 左右操作类型
        /// </summary>
        public string ExpressionType;
    }
}