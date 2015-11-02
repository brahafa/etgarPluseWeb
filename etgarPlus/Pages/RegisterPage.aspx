<%@ Page Title="הרשמה" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/RegisterPage.aspx.cs" Inherits="etgarPlus.Pages.RegisterPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="left_column_Body" runat="server">
    <h1><%: Title %></h1>
    <form runat="server">
        <h4>משתמש חדש:</h4>
        <hr />
        <div>
            
            <label class="RegisterLabel">*אימייל:</label>
            <input id="Email" class="RegisterField" runat="server" name="Email" type="text" />         
        </div>
        <div>
            <label class="RegisterLabel">*סיסמה:</label>
            <input id="password" class="RegisterField" runat="server" name="password" type="password" />
        </div>
        <div>
            <label class="RegisterLabel">*שם איש קשר:</label>
            <input id="contactName" class="RegisterField" runat="server" name="ContactName" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">שם העסק:</label>
            <input id="NameC" class="RegisterField" runat="server" name="BuisnessName" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">רחוב ומספר:</label>
            <input id="address" class="RegisterField" runat="server" name="address" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">עיר:</label>
            <select class="DropeDownListServer" id="selected_City" runat="server" onchange="NewCity()">

            </select>      

        </div>
        <div>
            <label class="RegisterLabel">מיקוד:</label>
            <input id="zipCode" class="RegisterField" runat="server" name="zip" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">טלפון עסק:</label>
            <input id="phone" class="RegisterField" runat="server" name="BuisnessPhone" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">*טלפון איש קשר:</label>
            <input id="contactPhone" class="RegisterField" runat="server" name="ContactPhone" type="text" />
        </div>
        <div>
            <label class="RegisterLabel">שעות פעילות העסק:</label>
            <input id="openTime" class="RegisterField" runat="server" name="OpenTime" type="text" />
        </div>

        <div>
            <asp:Button runat="server" OnClick="add_new_client" Text="הרשם" />
        </div>
       
    </form>
</asp:Content>
