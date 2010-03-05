using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using App.Domain.Products;
using App.Models.Products;

public partial class _Default : System.Web.UI.Page 
{
    ProductManager mgr = new ProductManager();
    Product product = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        PopulateProductData();
    }

    private void PopulateProductData()
    {
        ddlProductType.DataSource = mgr.GetProductCategoryList();
        ddlProductType.DataBind();
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        product = new Product();
        product.ProductName = txtProductName.Text;
        product.CategoryId = Convert.ToInt32(ddlProductType.SelectedValue);
        product.Price = Convert.ToDecimal(txtProductPrice.Text);

        mgr.SaveOrUpdate(product);
    }
}
