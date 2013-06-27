<%@ Page Title="Mimsy Record Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
            </hgroup>
            <span style="float: left; margin-right: 20px;">
                <label for="typesDropDown">Document Type</label>
                <asp:DropDownList ID="typesDropDown" runat="server"></asp:DropDownList>
            </span>

            <label for="titleSearchBox">Document Title</label>
            <asp:TextBox ID="titleSearchBox" runat="server"></asp:TextBox>
            
            <asp:Button ID="searchButton" runat="server" Text="Search" onClick="doSearch"/>
        </div>
    </section>
    <asp:SqlDataSource runat="server" ID="MmsyDataSource" ConnectionString='<%$ ConnectionStrings:MmsydataConnectionString %>' ProviderName='<%$ ConnectionStrings:MmsydataConnectionString.ProviderName %>' SelectCommand="SELECT [objtype] FROM [Type]"></asp:SqlDataSource>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="recordGrid" runat="server" OnSelectedIndexChanged="gridView_getRecord" OnPageIndexChanging="gridView_PageIndexChanging" OnSorting="gridView_Sorting" AutoGenerateSelectButton="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="false"></asp:GridView>
</asp:Content>
