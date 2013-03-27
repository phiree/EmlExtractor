using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EEBiz;
using EEModel;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //EEBiz.ContentExtractor ce = new EEBiz.ContentExtractor(@"E:\workspace\code\resources\中国制造有产品.eml");
        //ce.ExtractInfo();

        
    }

    private void Bind(IList<EEModel.ExtractorResultObject> resultList)
    {
        GridView1.DataSource = resultList;
        GridView1.DataBind();
    }
    EEBiz.ExtractService bllService = new ExtractService();
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        DateTime dtBegin=DateTime.Parse(tbxBegin.Text);
        DateTime dtEnd=DateTime.Parse(tbxEnd.Text);
        IList<ExtractorResultObject> resultList = bllService.GetList(dtBegin, dtEnd);
        Bind(resultList);
    }
}