<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Tom Navarro</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Web:</h3>
        </header>
        <p>
            <span><a href="http://nifelhe.im">http://nifelhe.im</a></span>
        </p>
        <p>
            <span class="label">Portfolio:</span>
            <span><a href="http://nifelhe.im/portfolio.html">http://nifelhe.im/portfolio.html</a></span>
        </p>
        <p>
            <span class="label">Resume:</span>
            <span><a href="http://nifelhe.im/resume.html">http://nifelhe.im/resume.html</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span><a href="mailto:tom@nifelhe.im">tom@nifelhe.im</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Social:</h3>
        </header>
        <p>
            <span class="label">Github:</span>
            <span><a href="https://github.com/atomvan">Atomvan</a></span>
        </p>
        <p>
            <span class="label">Linkedin:</span>
            <span><a href="http://lnkd.in/TtKRfG">Tom Navarro</a></span>
        </p>
        <p>
            <span class="label">Google+:</span>
            <span><a href="https://plus.google.com/u/0/104269842067547605287">Tom Navarro</a></span>
        </p>
    </section>
</asp:Content>