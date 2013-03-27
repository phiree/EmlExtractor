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
        private const string TableName = "EEInquery";

        SQLiteConnection cnn = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqliteConn"].ConnectionString);
        public void SaveBatch(IList<EEModel.ExtractorResultObject> resultObjectList)
        {
            cnn.Open();
            using (SQLiteTransaction mytransaction = cnn.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                {
                    SQLiteParameter paramClerkName = new SQLiteParameter();

                    SQLiteParameter paramProductName = new SQLiteParameter();
                    SQLiteParameter paramPlatForm = new SQLiteParameter();
                    SQLiteParameter paramCustomName = new SQLiteParameter();
                    SQLiteParameter paramCustomEmail = new SQLiteParameter();
                    SQLiteParameter paramInqueryTime = new SQLiteParameter();
                    SQLiteParameter paramCustomCountry = new SQLiteParameter();
                    SQLiteParameter paramCreationTime = new SQLiteParameter();
                    SQLiteParameter paramEmailTitle = new SQLiteParameter();
                    SQLiteParameter paramItemHashcode = new SQLiteParameter();

                    mycommand.CommandText = @"INSERT INTO [EEInquery] 
                                                        (ClerkName,ProductName,PlatFrom
                                                         ,CustomName,CustomEmail,InqueryTime
                                                         ,CustomCountry,CreationTime,EmailTitle,ItemHashcode)
                                                                    VALUES(?,?,?,?,
                                                                           ?,?,?,?
                                                                            ,?,?)";
                    mycommand.Parameters.Add(paramClerkName);
                    mycommand.Parameters.Add(paramProductName);
                    mycommand.Parameters.Add(paramPlatForm);
                    mycommand.Parameters.Add(paramCustomName);

                    mycommand.Parameters.Add(paramCustomEmail);

                    mycommand.Parameters.Add(paramInqueryTime);
                    mycommand.Parameters.Add(paramCustomCountry);
                    mycommand.Parameters.Add(paramCreationTime);
                    mycommand.Parameters.Add(paramEmailTitle);
                    mycommand.Parameters.Add(paramItemHashcode);
                    for (int n = 0; n < resultObjectList.Count; n++)
                    {
                        paramCreationTime.Value = resultObjectList[n].CreationTime;
                        paramClerkName.Value = resultObjectList[n].ClerkName;
                        paramCustomCountry.Value = resultObjectList[n].CustomCountry;
                        paramCustomEmail.Value = resultObjectList[n].CustomEmail;

                        paramCustomName.Value = resultObjectList[n].CustomName;
                        paramInqueryTime.Value = resultObjectList[n].InquiryTime;
                        paramPlatForm.Value = resultObjectList[n].PlatFrom;
                        paramProductName.Value = resultObjectList[n].ProductName;
                        paramItemHashcode.Value = resultObjectList[n].GetHashCode();
                        paramEmailTitle.Value = resultObjectList[n].EmailTitle;

                        mycommand.ExecuteNonQuery();
                    }
                }
                mytransaction.Commit();

            }
            cnn.Close();
        }

        public void Save(EEModel.ExtractorResultObject result)
        {
            IList<EEModel.ExtractorResultObject> tempList = new List<EEModel.ExtractorResultObject>();
            tempList.Add(result);
            SaveBatch(tempList);
        }



        public IList<EEModel.ExtractorResultObject> RemoveExists(IList<EEModel.ExtractorResultObject> resultObjectList, out IList<EEModel.ExtractorResultObject> dulpObject)
        {
            IList<EEModel.ExtractorResultObject> r = new List<EEModel.ExtractorResultObject>();
            dulpObject = new List<EEModel.ExtractorResultObject>();

            cnn.Open();
            using (SQLiteTransaction mytransaction = cnn.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
                {

                    SQLiteParameter paramItemHashcode = new SQLiteParameter();

                    mycommand.CommandText = @"select id from eeinquery where ItemHashcode=?";

                    mycommand.Parameters.Add(paramItemHashcode);

                    for (int n = 0; n < resultObjectList.Count; n++)
                    {

                        paramItemHashcode.Value = resultObjectList[n].GetHashCode();
                        object queryResult = mycommand.ExecuteScalar();
                        if (queryResult == null)
                        {
                            r.Add(resultObjectList[n]);
                        }
                        else
                        {
                            dulpObject.Add(resultObjectList[n]);
                        }


                    }
                }
                mytransaction.Commit();

            }
            cnn.Close();
            return r;
        }


        public IList<EEModel.ExtractorResultObject> GetList(DateTime beginRequiryTime, DateTime endRequiryTime)
        {
            IList<EEModel.ExtractorResultObject> resultObjectList = new List<EEModel.ExtractorResultObject>();

            cnn.Open();

            using (SQLiteCommand mycommand = new SQLiteCommand(cnn))
            {

                SQLiteParameter paramEndInquiry = new SQLiteParameter();
                SQLiteParameter paramBeginInquiry = new SQLiteParameter();

                mycommand.CommandText = @"select * from eeinquery where inqueryTime between ? and ?";
                mycommand.Parameters.Add(paramBeginInquiry);
                mycommand.Parameters.Add(paramEndInquiry);

                paramBeginInquiry.Value = beginRequiryTime;
                paramEndInquiry.Value = endRequiryTime;

                SQLiteDataReader reader = mycommand.ExecuteReader();
                while (reader.Read())
                {
                    EEModel.ExtractorResultObject oneResult = new EEModel.ExtractorResultObject();
                    oneResult.ClerkName = reader["ClerkName"].ToString();
                    oneResult.CreationTime = DateTime.Now;
                    oneResult.CustomCountry = reader["CustomCountry"].ToString();
                    oneResult.CustomEmail = reader["CustomEmail"].ToString();
                    oneResult.CustomName = reader["CustomName"].ToString();
                    oneResult.EmailTitle = reader["EmailTitle"].ToString();
                    oneResult.InquiryTime = Convert.ToDateTime(reader["InqueryTime"]);
                    oneResult.PlatFrom = (EEModel.enumPlatFrom)Convert.ToInt16(reader["PlatFrom"].ToString());
                    oneResult.ProductName = reader["ProductName"].ToString();
                    resultObjectList.Add(oneResult);
                }



            }
            cnn.Close();
            return resultObjectList;
        }
    }
}
