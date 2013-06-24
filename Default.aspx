<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
            <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from
                ASP.NET. If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <label for="typesDropDown">Document Type</label>
    <asp:DropDownList ID="typesDropDown" runat="server"></asp:DropDownList>
    <label for="titleSearchBox">Document Title</label>
    <asp:TextBox ID="titleSearchBox" runat="server"></asp:TextBox>
    <asp:Button ID="searchButton" runat="server" Text="Search" onClick="doSearch"/>

    <asp:GridView ID="documentGrid" runat="server" AutoGenerateColumns="True" AllowPaging="True" AllowSorting="True">
    </asp:GridView>
    <asp:SqlDataSource runat="server" ID="MmsyDataSource" ConnectionString='<%$ ConnectionStrings:MmsydataConnectionString %>' ProviderName='<%$ ConnectionStrings:MmsydataConnectionString.ProviderName %>' SelectCommand="SELECT [objtype] FROM [Type]"></asp:SqlDataSource>
</asp:Content>
