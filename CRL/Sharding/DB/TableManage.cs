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
using System.Text;

namespace CRL.Sharding.DB
{
    public class TableManage : CRL.BaseProvider<Table>
    {
        public static TableManage Instance
        {
            get { return new TableManage(); }
        }
        /// <summary>
        /// 创建表配置
        /// </summary>
        /// <param name="db"></param>
        /// <param name="table"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool Create(DataBase db, Table table,out string error)
        {
            error = "";
            table.DataBaseName = db.Name;
            if (table.IsMainTable)
            {
                table.MaxPartDataTotal = db.MaxMainDataTotal;//数据表的最大数据量=主数据表最大数据量（库容量为10）
            }
            table.TablePartTotal = 1; //分表数
            var item = QueryItem(b => b.DataBaseName == table.DataBaseName && b.TableName == table.TableName);
            if (item != null)
            {
                error = "有重复的表" + table.TableName;
                return false;
            }
            Add(table);
            //生成分表
            var part = new TablePart();
            part.DataBaseName = table.DataBaseName;
            part.TableName = table.TableName;
            if (table.IsMainTable)
            {
                part.MainDataStartIndex = db.MainDataStartIndex;
                part.MainDataEndIndex = db.MainDataEndIndex;
            }
            else
            {
                part.MainDataStartIndex = db.MainDataStartIndex;
                part.MainDataEndIndex = db.MainDataStartIndex + table.MaxPartDataTotal - 1;//单个订单表容量为5
            }
            part.PartName = table.TableName;
            DBExtend.InsertFromObj(part);
            return true;
        }
    }
}
