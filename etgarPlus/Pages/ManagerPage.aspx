<%@ Page Title="איזור ניהול" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/ManagerPage.aspx.cs" Inherits="etgarPlus.Pages.ManagerPage" Async="true" %>

<%--@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="left_column_Body">
    <h1><%: Title %></h1>
    <form id="form1" runat="server">
        <input type="text" id="clientId" style="display: none" runat="server" value="0" />
        <div>
            <a href="../Pages/AddProduct">
                <input class="button" type="button" value="הוסף מוצר" />
            </a>
            <input id="ViewUpdateButton" class="button" type="button" value="עידכון טבלאות" />
            <input id="ViewAllproductButton" class="button" type="button" value="הצג את כל המוצרים" />
            <input id="ViewAllClientButton" class="button" type="button" value="הצג את כל הלקוחות" style="display: inline" />
            <input id="ViewNewClientButton" class="button" type="button" value="הצג רק לקוחות חדשים" style="display: none" />
        </div>

        <div id="newClientDiv" style="display: inline" runat="server">
            <br />
            <asp:Table ID="newClientTable" runat="server" Width="100%">
                <asp:TableRow>
                    <%--<asp:TableCell ForeColor="#000000" BackColor="#ffffff">Id</asp:TableCell>--%>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">שם העסק</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">טלפון העסק</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">כתובת</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">עיר</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">מיקוד</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">שם איש קשר</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">טלפון איש קשר</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">שעות פתיחה</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">Email</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">סיסמה</asp:TableCell>
                    <asp:TableCell ID="newprise" ForeColor="#000000" BackColor="#ffffff">דרגת מחיר</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div id="allClientDiv" style="display: none" runat="server">
            <br />
            <asp:Table ID="allClientTable" runat="server" Width="100%">
                <asp:TableRow>
                    <%--<asp:TableCell ForeColor="#000000" BackColor="#ffffff">Id</asp:TableCell>--%>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">שם העסק</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">טלפון העסק</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">כתובת</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">עיר</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">מיקוד</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">שם איש קשר</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">טלפון איש קשר</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">שעות פתיחה</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">Email</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">סיסמה</asp:TableCell>
                    <asp:TableCell ID="allprise" ForeColor="#000000" BackColor="#ffffff">דרגת מחיר</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div id="allProductDiv" style="display: none" runat="server">
            <asp:Table ID="allProductTable" runat="server" Width="100%">
                <asp:TableRow>
                    <%--<asp:TableCell ForeColor="#000000" BackColor="#ffffff">Id</asp:TableCell>--%>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">שם היצרן</asp:TableCell>
                    <%--<asp:TableCell ForeColor="#000000" BackColor="#ffffff">שם הדגם</asp:TableCell>--%>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">קטגוריה ראשית</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">קטגוריה משנית</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">מידה</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">צבע</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">כמות</asp:TableCell>
                    <asp:TableCell ForeColor="#000000" BackColor="#ffffff">מחיר</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div id="UpdateDiv" style="display: none" runat="server">
            <br />
            <div id="producer">
                <label class="MyAccountLabel">שם יצרן:</label>
                <select class="DropeDownListServer" id="selected_producer" name="selected_producer" runat="server">
                    <option value="-1">בחר יצרן:</option>

                </select>
                <input type="text" id='elseProducer' runat='server' placeholder='הוסף יצרן' style="display: none" />
                <input type="button" id='DeleteProducer' runat='server' value='מחק' onclick="UpdateProd_click" />
            </div>
            <div id="categoriDiv">
                <label class="MyAccountLabel">קטגוריה:</label>
                <select class="DropeDownListServer" id="selected_Category" runat="server" onchange="NewCategory()">
                    <option value="-1">בחר קטגוריה:</option>
                </select>
                <input type="text" id='elseCategory' runat='server' placeholder='הוסף קטגוריה' style="display: none" />
                <input type="button" id='DeleteelseCategory' runat='server' value='מחק' />


            </div>
            <div id="SubCategoryDiv">
                <label class="MyAccountLabel">תת קטגוריה:</label>
                <select class="DropeDownListServer" id="selected_SubCategory" runat="server">
                    <option value="-1">בחר תת קטגוריה:</option>
                </select>
                <input type="text" id='elseSubCategory' runat='server' placeholder='הוסף תת קטגוריה' style="display: none" />
                <input type="button" id='DeleteElseSubCategory' runat='server' value='מחק' />
            </div>
            <div id="SizeDiv">
                <label class="MyAccountLabel">גודל:</label>
                <select class="DropeDownListServer" id="selected_Size" runat="server">
                    <option value="-1">בחר גודל:</option>
                </select>
                <input type="text" id='elseSize' runat='server' placeholder='הוסף גודל' style="display: none" />
                <input type="button" id='DeleteElseSize' runat='server' value='מחק' />
            </div>
            <div id="ColorDiv">
                <label class="MyAccountLabel">צבע:</label>
                <select class="DropeDownListServer" id="selected_Color" runat="server">
                    <option value="-1">בחר צבע:</option>
                </select>
                <input type="text" id='elseColor' runat='server' placeholder='הוסף צבע' style="display: none" />
                <input type="button" id='DeleteElseColor' runat='server' value='מחק' />
            </div>
        </div>

    </form>
</asp:Content>
