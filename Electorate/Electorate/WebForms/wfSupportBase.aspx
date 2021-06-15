<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfSupportBase.aspx.cs" Inherits="Electorate.WebForms.wfSupportBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="pageHeader" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BreadCrumbs" runat="server">
    <div class="row mb-2">
        <div class="col-sm-6">
            <h1 class="m-0 text-dark">Resident Information</h1>
        </div>
        <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">
                <li class="breadcrumb-item"><a href="#">Home</a></li>
                <li class="breadcrumb-item active">Resident Information</li>
            </ol>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-sm-3">
        </div>
        <div class="col-sm-6">
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Quick Example</h3>
                </div>
                <!-- /.card-header -->
                <!-- form start -->
                <form>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="exampleInputEmail1">Barangay</label>
                            <asp:DropDownList ID="ddBrgy" runat="server" CssClass="form-control">
                                <asp:ListItem>Select</asp:ListItem>
                                <asp:ListItem>	Balud	</asp:ListItem>
                                <asp:ListItem>	Balungag	</asp:ListItem>
                                <asp:ListItem>	Basak	</asp:ListItem>
                                <asp:ListItem>	Bugho	</asp:ListItem>
                                <asp:ListItem>	Cabatbatan	</asp:ListItem>
                                <asp:ListItem>	Green Hills	</asp:ListItem>
                                <asp:ListItem>	Ilaya	</asp:ListItem>
                                <asp:ListItem>	Lantawan	</asp:ListItem>
                                <asp:ListItem>	Liburon	</asp:ListItem>
                                <asp:ListItem>	Magsico	</asp:ListItem>
                                <asp:ListItem>	Panadtaran	</asp:ListItem>
                                <asp:ListItem>	Pitalo	</asp:ListItem>
                                <asp:ListItem>	Poblacion North	</asp:ListItem>
                                <asp:ListItem>	Poblacion South	</asp:ListItem>
                                <asp:ListItem>	San Isidro	</asp:ListItem>
                                <asp:ListItem>	Sangat	</asp:ListItem>
                                <asp:ListItem>	Tabionan	</asp:ListItem>
                                <asp:ListItem>	Tananas	</asp:ListItem>
                                <asp:ListItem>	Tinubdan	</asp:ListItem>
                                <asp:ListItem>	Tonggo	</asp:ListItem>
                                <asp:ListItem>	Tubod	</asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="exampleInputEmail1">Resident Name</label>
                            <input type="text" class="form-control" id="exampleInputEmail1" placeholder="Enter Name">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputPassword1">Sitio/Purok</label>
                            <input type="text" class="form-control" id="exampleInputPassword1" placeholder="Sitio/Purok">
                        </div>
                        <div class="form-group">
                            <label for="exampleInputFile">File input</label>
                            <div class="input-group">
                                <div class="custom-file">
                                    <input type="file" class="custom-file-input" id="exampleInputFile">
                                    <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                                </div>
                                <div class="input-group-append">
                                    <span class="input-group-text">Upload</span>
                                </div>
                            </div>
                        </div>
                        <div class="form-check">
                            <input type="checkbox" class="form-check-input" id="exampleCheck1">
                            <label class="form-check-label" for="exampleCheck1">Check me out</label>
                        </div>
                    </div>
                    <!-- /.card-body -->

                    <div class="card-footer">
                        <button type="submit" class="btn btn-primary">Submit</button>
                    </div>
                </form>
            </div>

        </div>
        <div class="col-sm-3">
        </div>
    </div>


</asp:Content>
