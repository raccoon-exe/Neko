<%@ Page Title="Selected Record" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Results.aspx.cs" Inherits="Results" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
            </hgroup>
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">


    <asp:DetailsView ID="mimsyRecord" runat="server" Height="50px" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"></AlternatingRowStyle>

        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True"></CommandRowStyle>

        <EditRowStyle BackColor="#999999"></EditRowStyle>

        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True"></FieldHeaderStyle>

        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>

        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#284775" ForeColor="White"></PagerStyle>

        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
    </asp:DetailsView>

    <hgroup class="title">
        <h1>Related Documents</h1>
    </hgroup>
    <p id="noRecordMessage" runat="server" style="visibility:hidden;">
        No related documents were found.
    </p>
    <asp:GridView ID="documentGrid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="true"></asp:GridView>
</asp:Content>