<%@ Page Title="דף הבית" Language="C#" MasterPageFile="~/Pages/Site.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="etgarPlus.Pages.Main" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="left_column_Body" runat="server">
    <h1><%: Title %></h1>
    <form id="form1" runat="server">
        <hr />
        <div class="searchDiv">
            <select class="searchitems" id="selected_producer" name="selected_producer" runat="server">
                <option value="-1">בחר יצרן</option>
            </select>
            <select class="searchitems" id="selected_Category_Main" runat="server">
                <option value="-1">בחר קטגוריה</option>
            </select>
            <select class="searchitems" id="selected_SubCategory_main" runat="server">
                <option value="-1">בחר תת קטגוריה</option>
            </select>
            <select class="searchitems" id="selected_Size" runat="server">
                <option value="-1">בחר גודל</option>
            </select>
            <select class="searchitems" id="selected_Color" runat="server">
                <option value="-1">בחר צבע</option>
            </select>
            <asp:Label CssClass="searchitems" ID="LabelFromPrice" runat="server" Text="ממחיר:" Width="125px"></asp:Label>
            <input class="searchitems" type="text" id="FromPriceInput" runat="server" placeholder="0" />
            <asp:Label CssClass="searchitems" ID="LabelToPrice" runat="server" Text="עד מחיר:" Width="125px"></asp:Label>
            <input class="searchitems" type="text" id="ToPriceInput" runat="server" placeholder="0" />
            <asp:Button id="searchButton" CssClass="searchitems" runat="server" OnClick="search_Click" Text="סנן" Width="125px" />

            <%--<select class="DropeDownListServer" id="tessst" runat="server">
                <option value="-1">תוצאה:</option>
            </select>--%>
        </div>
        <hr />
        <br />
        <input type="text" id="bikeId" style="display: none" runat="server" value="0" />
        <div id="new_released_section">
            <%  for (int i = 0; i < listBike.Count; i++)
                { %>
            <div class='new_released_box' id='<% =listBike[i]._Id %>'>
                <img src='<% =listBike[i]._ImagePath %>' alt='<% =producerBL.GetProducer(listBike[i]._Name)%>' /><h3><% =producerBL.GetProducer(listBike[i]._Name) %>  </h3>
                <asp:Button runat="server" OnClientClick="setBikeID($(this).last().parent().prop('id'));" OnClick="bikeButton_Click" Text="פרטים נוספים" />
            </div>

            <%}%>
        </div>
        <div id="properties" class="white_content" runat="server">
            <label onclick="closeProperties()">Close </label>
            <div id="bikeProperties" style="color: black; height: 218px;">
                <asp:Label ID="NameLabel" runat="server" Text="שם היצרן:"></asp:Label>
                <asp:Label ID="Name" runat="server" Text="test"></asp:Label>
                <br />
                <asp:Image ID="Image1" runat="server" Height="140px" ImageAlign="Left" Width="200px" />
                <div  style='display:none '>
                    <asp:Label ID="ModelLabel" runat="server" Text="שם הדגם:"></asp:Label>
                    <asp:Label ID="Model" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <asp:Label ID="MainCategoryLabel" runat="server" Text="קטגוריה ראשית:"></asp:Label>
                <asp:Label ID="MainCategory" runat="server" Text="test"></asp:Label>
                <br />
                <asp:Label ID="SubCategoryLabel" runat="server" Text="קטגוריה משנית:"></asp:Label>
                <asp:Label ID="SubCategory" runat="server" Text="test"></asp:Label>
                <br />
                <asp:Label ID="SizeLabel" runat="server" Text="מידה:"></asp:Label>
                <asp:Label ID="Size" runat="server" Text="test"></asp:Label>
                <br />
                <asp:Label ID="ColorLabel" runat="server" Text="צבע:"></asp:Label>
                <asp:Label ID="Color" runat="server" Text="test"></asp:Label>
                <br />
                <asp:Label ID="QuantityLabel" runat="server" Text="כמות במלאי:"></asp:Label>
                <asp:Label ID="Quantity" runat="server" Text="test"></asp:Label>
                <br />
                <asp:Label ID="PriceLabel" runat="server" Text="מחיר מומלץ לצרכן:"></asp:Label>
                <asp:Label ID="Price" runat="server" Text="test"></asp:Label>
                <asp:Label ID="PriceLabel2" runat="server" Text="שח"></asp:Label>
                <%if (Session["Email"] != null)
                  { %>
                <br /><br /><br /><hr />
                <select class="propertieItems" id="selectQuantity" name="selected_producer" runat="server">
                    <option value="-1">בחר כמות:</option>
                </select>
                <asp:Button id="addButton" CssClass="propertieItems" runat="server" OnClick="addToList_Click" Text="הוסף לסל" Width="125px" BorderColor="Black" BorderWidth="1" Height="22" />
                <%} %>
            </div>
        </div>
        <div id="fade" class="black_overlay" onclick="closeProperties()" runat="server"></div>

        <div id="addTOBasket" class="white_content" runat="server">
            <label onclick="closeProperties()">Close </label>
            <label onclick="closeAddToList()">Close </label>
            <div>
                <h1>המוצר נוסף בהצלחה!</h1>
            </div>
        </div>

        <div id="fade2" class="black_overlay" onclick="closeAddToList()" runat="server"></div>
    </form>
</asp:Content>
