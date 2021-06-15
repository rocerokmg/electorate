<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="wfLogin.aspx.cs" Inherits="Electorate.WebForms.wfLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="~/plugins/fontawesome-free/css/all.min.css" />
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="~/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="~/dist/css/adminlte.min.css" />
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div class="login-box">
            <div class="login-logo">
               <a href="../../index2.html"><b><i class="fa fa-address-book"></i></b> SF Tracker</a>
            </div>
            <!-- /.login-logo -->
            <div class="card">
                <div class="card-body login-card-body">
                    <p class="login-box-msg">Sign in to start your session</p>

                    <form>
                        <div class="input-group mb-3">                            
                            <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email Address"></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-envelope"></span>
                                </div>
                            </div>
                        </div>
                        <div class="input-group mb-3">
                             <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>                           
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <div class="icheck-primary">
                                    <input type="checkbox" id="remember">
                                    <label for="remember">
                                        Remember Me
                                    </label>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-4">                                
                                <asp:Button ID="btnSignIn" runat="server"  class="btn btn-primary btn-block" Text="Sign In" OnClick="btnSignIn_Click" />
                            </div>
                            <!-- /.col -->
                        </div>
                    </form>
                    <p>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </p>
                    <p class="mb-1 mb-5">
                        <a href="forgot-password.html">I forgot my password</a>
                    </p>
                  
                </div>
                <!-- /.login-card-body -->
            </div>
        </div>
        <!-- /.login-box -->

        <!-- jQuery -->
        <script src="~/plugins/jquery/jquery.min.js"></script>
        <!-- Bootstrap 4 -->
        <script src="~/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- AdminLTE App -->
        <script src="~/dist/js/adminlte.min.js"></script>
    </form>
</body>
</html>
