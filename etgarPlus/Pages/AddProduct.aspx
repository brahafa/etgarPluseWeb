<%@ Page Title="הוספת מוצר" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/AddProduct.aspx.cs" Inherits="etgarPlus.Pages.AddProduct" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="left_column_Body" runat="server">
    <h1><%: Title %></h1>
    <form id="addProd" runat="server" enctype="multipart/form-data">
        <div id="producer">
            <label class="MyAccountLabel">*כותרת:</label>
            <select class="DropeDownListServer" id="selected_producer" name="selected_producer" runat="server">
                <option value="-1">בחר יצרן:</option>

            </select>
            <input type='text' id='elseProducer' runat='server' placeholder='הוסף שם יצרן חדש' style='display:none '/>

        </div>
        <div  style='display:none '>
            <label class="MyAccountLabel">דגם:</label>
            <input class="MyAccountField" id="Model" runat="server" type="text" />
            <%--<asp:Image ID="img1" runat="server" Height="154px" Width="240px" ImageAlign="left" />--%>
        </div>
        <div id="categoriDiv">
            <label class="MyAccountLabel">קטגוריה*:</label>
            <select class="DropeDownListServer" id="selected_Category" runat="server" onchange="NewCategory()">
                <option value="-1">בחר קטגוריה:</option>
            </select>
                        <input type='text' id='elseCategory' runat='server' placeholder='הוסף קטגוריה חדשה' style='display:none '/>

        </div>
        <div id="SubCategoryDiv">
            <label class="MyAccountLabel">תת קטגוריה*:</label>
            <select class="DropeDownListServer" id="selected_SubCategory" runat="server">
                <option value="-1">בחר תת קטגוריה:</option>
            </select>
            <input type='text' id='elseSubCategory' runat='server' placeholder='הוסף תת קטגורי חדשה' style='display:none '/>
        </div>
        <div id="SizeDiv">
            <label class="MyAccountLabel">גודל*:</label>
            <select class="DropeDownListServer" id="selected_Size" runat="server">
                <option value="-1">בחר גודל:</option>
            </select>
            <input type='text' id='elseSize' runat='server'  placeholder='הוסף גודל חדש' style='display:none' />
        </div>
        <div id="ColorDiv">
            <label class="MyAccountLabel">צבע*:</label>
            <select class="DropeDownListServer" id="selected_Color" runat="server">
                <option value="-1">בחר צבע:</option>
            </select>
            <input type='text' id='elseColor' runat='server' placeholder='הוסף צבע חדש' style='display:none '/>
        </div>
        <div  style='display:none '>
            <label class="MyAccountLabel">מחיר קמונעי:</label>
            <input class="MyAccountField" id="RetailPrice" runat="server" type="text" />
        </div>
        <div>
            <label class="MyAccountLabel">מחיר רגיל:</label>
            <input class="MyAccountField" id="RegularPrice" runat="server" type="text" />

        </div>
        <div>
            <label class="MyAccountLabel">מחיר מועדון:</label>
            <input class="MyAccountField" id="ClubPrice" runat="server" type="text" />

        </div>
        <div>
            <label class="MyAccountLabel">כמות*:</label>
            <input class="MyAccountField" id="Quantity" runat="server" type="text" />
            

        </div>
            <div  style='display:inline '>
            <label class="MyAccountLabel">פרטים נוספים:</label>
             <asp:TextBox ID="Specification" width="235px" height="84px" textmode="MultiLine" runat="server"></asp:TextBox>
        </div>
        <div>
            <label class="MyAccountLabel">תמונה:</label>
           
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
    
        <div>
            <asp:Button runat="server" CssClass="addProductSubmit" OnClick="submitButton_Click" ID="submitButton" type="submit" name="Submit" value="submit" Text="הוסף" />
            <asp:Button runat="server" CssClass="addProductSubmit" name="resetutton" Text="מחיקה" value="reset" ID="btoonReset" OnClientClick="resetButtonJS_Click()" OnClick="resetButton_Click" />
        </div>
    </form>
</asp:Content>
