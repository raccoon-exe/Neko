<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %></h1>
        <h2>This App</h2>
    </hgroup>

    <article>
        <h1>
            Neko is...
        </h1>
        <p>        
            an application which provides a web interface to a Microsoft Access database.
        </p>

        <p>        
            Written in ASP.NET and C#.
        </p>
    </article>

    <aside>
        <h3>Source Code</h3>
        <p>        
            Fork this project on Github!
        </p>
        <ul>
            <li><a runat="server" href="https://github.com/atomvan/Neko">Source Code</a></li>
        </ul>
    </aside>
</asp:Content>