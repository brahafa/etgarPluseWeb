<%@ Page Title="דף לקוח" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/AccountPage.aspx.cs" Inherits="etgarPlus.Pages.AccountPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="left_column_Body" runat="server">
    <h1><%: Title %></h1>
    <form runat="server">
        <h4>שלום!</h4>
        <hr />
        <div>
            <label class="RegisterLabel">אימייל:</label>
            <input id="Email" class="AccountField" runat="server" name="Email" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">סיסמה:</label>
            <input id="pass" class="AccountField" runat="server" name="pass" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">שם איש קשר:</label>
            <input id="contactName" class="AccountField" runat="server" name="ContactName" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">שם העסק:</label>
            <input id="NameC" class="AccountField" runat="server" name="BuisnessName" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">רחוב ומספר:</label>
            <input id="address" class="AccountField" runat="server" name="address" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">עיר:</label>
            <input id="city" class="AccountField" runat="server" name="City" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">מיקוד:</label>
            <input id="zipCode" class="AccountField" runat="server" name="zip" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">טלפון עסק:</label>
            <input id="phone" class="AccountField" runat="server" name="BuisnessPhone" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">טלפון איש קשר:</label>
            <input id="contactPhone" class="AccountField" runat="server" name="ContactPhone" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">שעות פעילות העסק:</label>
            <input id="openTime" class="AccountField" runat="server" name="OpenTime" type="text" />
        </div>
        <%--not implemented yet--%>
        <div class="hide">
            <div>
                <label class="RegisterLabel">סטטוס הרשמה?</label>
                <input id="status" class="AccountField" runat="server" name="Status" type="text" />
            </div>
            <hr />
            <div>
                <asp:Button runat="server" OnClick="save" Text="שמור שינויים" />

            </div>
        </div>
    </form>
</asp:Content>
