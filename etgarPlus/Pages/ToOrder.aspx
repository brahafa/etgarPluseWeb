<%@ Page Title="סל הקניות שלי" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="~/Pages/ToOrder.aspx.cs" Inherits="etgarPlus.Pages.ToOrder" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="left_column_Body" runat="server">
    <h1><%: Title %></h1>
    <form runat="server">
        <div id="newListBikeDiv" runat="server">

            <asp:Table ID="newListBikeTable" runat="server" Width="100%">
                <asp:TableRow>
                    <asp:TableCell>שם היצרן</asp:TableCell>
                    <%--<asp:TableCell>שם הדגם</asp:TableCell>--%>
                    <asp:TableCell>קטגוריה ראשית</asp:TableCell>
                    <asp:TableCell>קטגוריה משנית</asp:TableCell>
                    <asp:TableCell>מידה</asp:TableCell>
                    <asp:TableCell>צבע</asp:TableCell>
                    <asp:TableCell>כמות</asp:TableCell>
                    <asp:TableCell>מחיר לפריט</asp:TableCell>
                    <asp:TableCell>מחיר כולל</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Button runat="server" ID="sendOrder" Text="שלח הזמנה" OnClick="sendEmail_Click" />
            <asp:Button runat="server" ID="cleanOrder" Text="נקה הזמנה" OnClick="cleanOrder_Click" />
        </div>
        <div id="fade" class="black_overlay" onclick="closeAll()" runat="server"></div>
        <div id="sendSucsses" class="white_content" runat="server">

            <div>
                <h1>ההזמנה נשלחה בהצלחה!</h1>
                <br />
                <h3>תודה שהזמנתם אצלנו, ניצור איתכם קשר בקרוב.</h3>
            </div>
        </div>
        <label onclick="closeAll()"></label>
    </form>
</asp:Content>
