<!DOCTYPE html>
<html>
    <body>
        <%
            response.write("Hello World!")
        %>
        <form id="form1" runat="server>
            <asp:AccessDataSource
                id="nekoDataSource"
                DataFile="App_Data/Mmsydata.accdb"
                runat="server"
                SelectCommand="SELECT objtype FROM Type" />
            <asp:GridView
                id="nekoGridView"
                runat="server"
                AutoGenerateColumns="True"
                DataSourceid="nekoDataSource" />
    </body>
</html>
