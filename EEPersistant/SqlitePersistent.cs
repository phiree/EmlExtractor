using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Data.SQLite;
namespace EEPersistant
{
    /// <summary>
    /// 将分析结果保存到sqlite数据库
    /// </summary>
    public class SqlitePersistent : IPersistent
    {
        public void Save(EEModel.ExtractorResutObject resultObject)
        {
            DbConnection conn = new SQLiteConnection();

            //conn.Open()
        }
    }
}
