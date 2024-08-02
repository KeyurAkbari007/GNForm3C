using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI;
using System;

public class DynamicTemplate : ITemplate
{
    private string _headerText;

    public DynamicTemplate(string headerText)
    {
        _headerText = headerText;
    }

    public void InstantiateIn(Control container)
    {
        TextBox txtBox = new TextBox();
        txtBox.ID = "txt" + _headerText;
        txtBox.CssClass = "form-control";
        txtBox.DataBinding += new EventHandler(OnDataBinding);
        container.Controls.Add(txtBox);
    }

    private void OnDataBinding(object sender, EventArgs e)
    {
        TextBox txtBox = (TextBox)sender;
        GridViewRow row = (GridViewRow)txtBox.NamingContainer;
        DataRowView dataItem = (DataRowView)row.DataItem;
        txtBox.Text = dataItem[_headerText].ToString();
    }
}
